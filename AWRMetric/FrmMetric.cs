using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.SQLite;
using System.Globalization;

namespace AWRMetric
{
    public partial class FrmMetric : Form
    {
        public FrmMetric()
        {
            InitializeComponent();
        }
        public int countIndex = 0;
        public bool Checked { get; set; }
        public string constr;
        public string regexpstr;
        public Int64 dbid;
        public Int64 instance_num;
        public string bSnapdate;
        public string eSnapdate;
        OracleConnection conn = new OracleConnection();
        SQLiteConnection con = new SQLiteConnection();
        public string delta_time_where_clause = "";
        public string metric_save_mode = "";
        bool errorfound = false;

        public void ConnectToSqllite()
        {
            
            try
            {
                string cs = @"URI=file:C:\AWRReader\AWRMetric\awrdb.db";
                con.ConnectionString = cs;
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to sqllite database. "+ex.Message);
            }
            finally
            {
                
            }
        }


        private void ConnectDatabase()
        {
            try
            {
                string oraconn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + txthost.Text + ")(PORT=" + txtport.Text + ")))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + txtservice.Text + ")));User Id=" + txtuser.Text + ";Password=" + txtpwd.Text + ";";
                conn.ConnectionString = oraconn;
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void bttnGetSnap_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT A.SNAP_ID, A.DBID,B.NAME, A.INSTANCE_NUMBER, A.BEGIN_INTERVAL_TIME, A.END_INTERVAL_TIME " +
                                         "FROM DBA_HIST_SNAPSHOT A,V$DATABASE B " +
                                         "WHERE TO_CHAR(TRUNC(BEGIN_INTERVAL_TIME),'YYYYMMDD') >= '" + dtsnap.Value.ToString("yyyyMMdd") + "' " +
                                         "AND TO_CHAR(TRUNC(BEGIN_INTERVAL_TIME),'YYYYMMDD') <= '" + dtsnapto.Value.ToString("yyyyMMdd") + "' " +
                                         "order by BEGIN_INTERVAL_TIME desc";
                ConnectDatabase();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                this.dg.Rows.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {DataGridViewRow dgvRow = new DataGridViewRow();
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        dgvRow.Cells[0].Value = dr["SNAP_ID"].ToString();
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        dgvRow.Cells[1].Value = dr["BEGIN_INTERVAL_TIME"].ToString();
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        
                        dgvRow.Cells[2].Value = dr["END_INTERVAL_TIME"].ToString();
                        dgvRow.Cells.Add(new DataGridViewCheckBoxCell());
                        dgvRow.Cells[3].Value = 0;
                        dg.Rows.Add(dgvRow);
                        dbid = Convert.ToInt64(dr["DBID"]);
                        instance_num = Convert.ToInt64(dr["INSTANCE_NUMBER"]);
                    }
                }
                else
                {
                    MessageBox.Show("No Snapshot found!.");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            

        }

        private void lstCollection_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void FrmMetric_Load(object sender, EventArgs e)
        {
            tv.Enabled = false;
            get_savepointsdate();
            this.reportViewer1.RefreshReport();
        }

        public void get_savepointsdate()
        {
            ConnectToSqllite();
            try
            {
                dgsavept.DataSource = null;
                dgsavept.Rows.Clear();
                string sql = "select distinct SNAP_TIME,SAVEPOINT_DATE from tblWorkload where ISBASEPOINT = 1";
                DataTable sqldt = new DataTable();
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sql, con);
                sqlda.Fill(sqldt);
                if (sqldt.Rows.Count > 0)
                {
                    foreach (DataRow row in sqldt.Rows)
                    {
                        DataGridViewRow dgvRow = new DataGridViewRow();
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        dgvRow.Cells[0].Value = row["SNAP_TIME"].ToString();
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        dgvRow.Cells[1].Value = row["SAVEPOINT_DATE"].ToString();
                        dgsavept.Rows.Add(dgvRow);
                    }
                }
                else
                {
                    MessageBox.Show("Please create Savepoint.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                
            }
        }


        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                dg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if ((bool)dg.CurrentCell.Value == true)
            {
                dg.Rows[e.RowIndex].Cells[3].Value = 1;
                DataGridViewRow row = dg.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Yellow;

            }
            else
            {
                dg.Rows[e.RowIndex].Cells[3].Value = 0;
                DataGridViewRow row = dg.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.White;
            }

        }

        public void HighlightCheckedNodes()
        {
            countIndex = 0;
            string selectedNode = "";
            foreach (TreeNode node in tv.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode myNode in node.Nodes)
                    {
                        // Check whether the tree node is checked.
                        if (myNode.Checked)
                        {
                            // Set the node's backColor.
                            node.BackColor = Color.Yellow;
                            myNode.BackColor = Color.Yellow;
                            selectedNode += myNode.Text + ",";
                            countIndex++;
                        }
                        else
                        {
                            node.BackColor = Color.White;
                            myNode.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    if (node.Checked)
                    {
                        // Set the node's backColor.
                        node.BackColor = Color.Yellow;
                        selectedNode += node.Text + ",";
                        countIndex++;
                    }
                    else
                    {
                        node.BackColor = Color.White;
                    }
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void getsnapdates()
        {
            //delta_time_where_clause
            DateTime[] snapArray = new DateTime[2];
            int counter = 0;

            foreach (DataGridViewRow row in dg.Rows)
            {
                bool chkval = Convert.ToBoolean(row.Cells[3].Value);
                if (chkval == true)
                {
                    counter++;
                    if (counter == 1)
                    {
                        snapArray[0] = Convert.ToDateTime(row.Cells[2].Value);
                        snapArray[1] = Convert.ToDateTime(row.Cells[1].Value);
                    }
                    else
                    {
                        snapArray[1] = Convert.ToDateTime(row.Cells[1].Value);
                    }
                }
            }
            if (snapArray[0] > snapArray[1])
            {
                bSnapdate = snapArray[1].ToString("MM/dd/yyyy HH:mm:ss");
                eSnapdate = snapArray[0].ToString("MM/dd/yyyy HH:mm:ss");
            }
            else //if only one snap selected
            {
                bSnapdate = snapArray[1].ToString();
                eSnapdate = snapArray[0].ToString();
            }

            delta_time_where_clause = "between TO_DATE('" + bSnapdate + "', 'MM/dd/yyyy HH24:mi:ss') and TO_DATE('" + eSnapdate + "', 'MM/dd/yyyy HH24:mi:ss')";
            //MessageBox.Show(delta_time_where_clause);
            //create base points - call all functions
            workloaddata();
            sysstatdata();
            waitevent();
            waitclass();
            iostatdetails();
            iostatlatency();
            servicestat();
            topevents();
            if (errorfound == false)
            {
                MessageBox.Show("Basepoint created successfully.");
                return;
            }
            else
            {
                MessageBox.Show("Error occured on saving data, unable to create Basepoint!!");
                errorfound = false;
                return;
            }
        }

        private void metric_savepoint()
        {
            try
            {
                metric_save_mode = "'false' as ISBASEPOINT,'true' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE ";
                foreach (TreeNode myNode in tv.Nodes)
                {
                    // Check whether the tree node is checked.
                    if (myNode.Checked)
                    {

                        switch (myNode.Index)
                        {
                            case 0:
                                workloaddata();
                                break;
                            case 1:
                                sysstatdata();
                                break;
                            case 2:
                                waitevent();
                                break;
                            case 3:
                                waitclass();
                                break;
                            case 4:
                                iostatdetails();
                                break;
                            case 5:
                                iostatlatency();
                                break;
                            case 6:
                                servicestat();
                                break;
                            case 7:
                                topevents();
                                break;
                            default:
                                // Console.WriteLine("Default case");
                                break;
                        }
                    }
                    else
                    {
                        myNode.BackColor = Color.White;
                    }
                }
                if (errorfound == false)
                {
                    MessageBox.Show("Basepoint created successfully.");
                    return;
                }
                else
                {
                    MessageBox.Show("Error occured on saving data, unable to create Basepoint!!");
                    errorfound = false;
                    return;
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            

        }

        public void workloaddata()
        {
            try
            {
                string sql = "select '"+ txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME,cast(min(sn.begin_interval_time) over (partition by sn.dbid,sn.snap_id) as date) SNAP_TIME," +
                             //--ss.dbid,  --uncomment if you have multiple dbid in your AWR
                             "sn.instance_number as INSTANCE_NUMBER,ss.metric_name || ' - ' || ss.metric_unit  as METRIC_NAME_UNIT,ss.maxval as MAXVALUE," +
                             "ss.average as AVERAGE,ss.standard_deviation as STANDARD_DEVIATION," +
                             //'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE
                             "" + metric_save_mode + " " +
                             "from dba_hist_sysmetric_summary ss,dba_hist_snapshot sn " +
                             "where sn.snap_id = ss.snap_id and sn.dbid = ss.dbid and sn.instance_number = ss.instance_number " +
                             "and sn.begin_interval_time "+ delta_time_where_clause +" order by sn.snap_id";
                ConnectDatabase();
                
                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                        foreach (DataRow row in oradt.Rows)
                        {
                            SQLiteCommand sqlitecommand = new SQLiteCommand("insert into tblWorkLoad(" +
                                "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,METRIC_NAME_UNIT," +
                                "MAXVALUE,AVERAGE,STANDARD_DEVIATION,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "'," +
                                "" + Convert.ToDecimal(row[5]) + "," + Convert.ToDecimal(row[6]) + "," + Convert.ToDecimal(row[7]) + "," + Convert.ToInt64(row[8]) + "," + Convert.ToInt64(row[9]) + ",'" + Convert.ToString(row[10]) + "')", con);
                            {
                                sqlitecommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        /* crystal report chart 
                        DataSet Ds = new DataSet();
                        
                        oraAdapt.Fill(Ds, "dtWorkload");
                        
                        dgrid.DataSource= Ds.Tables["dtWorkload"];
                        string RptPath = "C:\\AWRReader\\AWRReader\\AWRReader\\";
                        string strSQL = "";
                        
                        crviewer.ToolPanelView = ToolPanelViewType.None;

                        rptworkload session = new rptworkload();
                        session.SetDataSource(Ds);
                        session.VerifyDatabase();
                        strSQL = "{dtWorkload.METRIC_NAME_UNIT} = 'Average Active Sessions - Active Sessions'";
                        session.RecordSelectionFormula = strSQL;
                        crviewer.ReportSource = session;
                        crviewer.RefreshReport();
                        */
                    }
                        catch (Exception Excon)
            {
                MessageBox.Show("Exception-->" + Excon.Message);
                transaction.Rollback();
                errorfound = true;
            }
            finally
            {
                con.Close();
            }
        }
                }
                else
                {
                    MessageBox.Show("No Workload Data found!.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                errorfound = true;
            }
            finally
            {
                conn.Close();
                con.Close();
            }
        }

        public void sysstatdata()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME, cast(min(sn.begin_interval_time) over(partition by sn.dbid, sn.snap_id) as date) snap_time," +//  --workaround to uniform snap_time over all instances in RAC
                              //"--ss.dbid,  --uncomment if you have multiple dbid in your AWR" +
                             "sn.instance_number," +
                             "replace(ss.stat_name,chr(39),' ') stat_nane," +
                             "ss.value," +
                             "ss.value - lag(ss.value) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first) Delta_value," +
                             "extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600" +
                                          "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first)) * 3600" +
                                          //"--deals with daylight savings time change"+
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time) DeltaT_sec," +
                             "round((ss.value - lag(ss.value) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first)) /" +
                                          "(extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600" +
                                          "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first)) * 3600" +
                                          //"--deals with daylight savings time change"+
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_value," +
                                          //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                          "" + metric_save_mode +" " +
                            "from dba_hist_sysstat ss," +
                                 "dba_hist_snapshot sn " +
                            "where " +
                            "sn.snap_id = ss.snap_id " +
                            "and sn.dbid = ss.dbid " +
                            "and sn.instance_number = ss.instance_number " +
                            "and sn.begin_interval_time " + delta_time_where_clause + "" +
                            "order by sn.snap_id";

                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                        foreach (DataRow row in oradt.Rows)
                        {
                            decimal mValue = 0;
                            decimal mDelta_value = 0;
                            decimal mDelta_sec = 0;
                            decimal mrate_value = 0;

                            if (row.IsNull("VALUE"))
                            {
                                mValue = 0;
                            }
                            else
                            {
                                mValue = Convert.ToDecimal(row[5]);
                            }

                            if (row.IsNull("DELTA_VALUE"))
                            {
                                mDelta_value = 0;
                            }
                            else
                            {
                                mDelta_value = Convert.ToDecimal(row[6]);
                            }

                            if (row.IsNull("DELTAT_SEC"))
                            {
                                mDelta_sec = 0;
                            }
                            else
                            {
                                mDelta_sec = Convert.ToDecimal(row[7]);
                            }

                            if (row.IsNull("RATE_VALUE"))
                            {
                                mrate_value = 0;
                            }
                            else
                            {
                                mrate_value = Convert.ToDecimal(row[8]);
                            }
                            
                            TSQL = "insert into tblSysstat(" +
                                "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,STAT_NAME," +
                                "VALUE,DELTA_VALUE,DELTA_SEC,RATE_VALUE,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "', " +
                                "" + mValue + "," + mDelta_value + "," + mDelta_sec + "," + mrate_value + "," + Convert.ToInt64(row[9]) + "," + Convert.ToInt64(row[10]) + ",'" + Convert.ToString(row[11]) + "')";
                            SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                            sqlitecommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                        catch (Exception Excon)
            {
                MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                transaction.Rollback();
                errorfound = true;
            }
            finally
            {
                con.Close();
            }
        }
                }
                else
                {
                    MessageBox.Show("No Sysstat Data found!.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->"+ex.Message);
                errorfound = true;

            }
            finally
            {
                conn.Close();
                con.Close();
            }
        }

        public void waitevent()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME, cast(min(sn.begin_interval_time) over (partition by sn.dbid, sn.snap_id) as date) snap_time," + //  --workaround to uniform snap_time over all instances in RAC
                             //"--ss.dbid,  --uncomment if you have multiple dbid in your AWR"+
                             "sn.instance_number," +
                             "ss.event_name," +
                             "ss.wait_class," +
                             "ss.total_waits," +
                             "ss.time_waited_micro," +
                             "ss.total_waits - lag(ss.total_waits) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first) Delta_waits," +
                             "ss.time_waited_micro - lag(ss.time_waited_micro) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first) Delta_timewaited," +
                             "round((ss.total_waits - lag(ss.total_waits) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) /" +
                                   "(extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600" +
                                          "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) * 3600" + //--deals with daylight savings time change
                                          "+extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Waits_per_sec," +
                             "round((ss.time_waited_micro - lag(ss.time_waited_micro) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) /" +
                                   "(extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600" +
                                          "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) * 3600" + //--deals with daylight savings time change
                                          "+extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_timewaited," + //--time_waited_microsec / clock_time_sec
                                "round((ss.time_waited_micro - lag(ss.time_waited_micro) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) /" +
                                       "nullif(ss.total_waits - lag(ss.total_waits) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first), 0),2) Avg_wait_time_micro," +
                                       //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                       "" + metric_save_mode + " " +
                              "from dba_hist_system_event ss," +
                                   "dba_hist_snapshot sn " +
                              "where " +
                                "sn.snap_id = ss.snap_id " +
                            "and sn.dbid = ss.dbid " +
                            "and sn.instance_number = ss.instance_number " +
                            "and sn.begin_interval_time " + delta_time_where_clause + " " +
                            "order by sn.snap_id";


                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                        foreach (DataRow row in oradt.Rows)
                        {
                            decimal mtotalwaits = 0;
                            decimal mtimewaitedmicro = 0;
                            decimal mdeltawaits = 0;
                            decimal mdeltatimewaited = 0;
                            decimal mwaitspersec = 0;
                            decimal mratetimewaited = 0;
                            decimal mavgwaittimemicro = 0;

                            if (row.IsNull("TOTAL_WAITS"))
                            {
                                mtotalwaits = 0;
                            }
                            else
                            {
                                mtotalwaits = Convert.ToDecimal(row[6]);
                            }

                            if (row.IsNull("TIME_WAITED_MICRO"))
                            {
                                mtimewaitedmicro = 0;
                            }
                            else
                            {
                                mtimewaitedmicro = Convert.ToDecimal(row[7]);
                            }

                            if (row.IsNull("DELTA_WAITS"))
                            {
                                mdeltawaits = 0;
                            }
                            else
                            {
                                mdeltawaits = Convert.ToDecimal(row[8]);
                            }

                            if (row.IsNull("DELTA_TIMEWAITED"))
                            {
                                mdeltatimewaited = 0;
                            }
                            else
                            {
                                mdeltatimewaited = Convert.ToDecimal(row[9]);
                            }

                            if (row.IsNull("WAITS_PER_SEC"))
                            {
                                mwaitspersec = 0;
                            }
                            else
                            {
                                mwaitspersec = Convert.ToDecimal(row[10]);
                            }

                            if (row.IsNull("RATE_TIMEWAITED"))
                            {
                                mratetimewaited = 0;
                            }
                            else
                            {
                                mratetimewaited = Convert.ToDecimal(row[11]);
                            }

                            if (row.IsNull("AVG_WAIT_TIME_MICRO"))
                            {
                                mavgwaittimemicro = 0;
                            }
                            else
                            {
                                mavgwaittimemicro = Convert.ToDecimal(row[12]);
                            }

                            TSQL = "insert into tblWaitevent(" +
                                "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,EVENT_NAME,WAIT_CLASS,TOTAL_WAITS,TIME_WAITED_MICRO,DELTA_WAITS,DELTA_TIMEWAITED,WAITS_PER_SEC," +
                                "RATE_TIMEWAITED,AVG_WAIT_TIME_MICRO,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "','" + Convert.ToString(row[5]) + "'," +
                                "" + mtotalwaits + "," + mtimewaitedmicro + "," + mdeltawaits + "," + mdeltatimewaited + "," + mwaitspersec + "," + mratetimewaited + "," + mavgwaittimemicro + "," + Convert.ToInt64(row[13]) + "," + Convert.ToInt64(row[14]) + ",'" + Convert.ToString(row[15]) + "')";
                            SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                            sqlitecommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Waitevent Data found!.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->" + ex.Message);
                errorfound = true;

            }
            finally
            {
                conn.Close();
                con.Close();
            }
        }


        public void waitclass()
        {
            string TSQL = "";
            try
            {
                string sql = "select  '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME,snap_time, snap_id, instance_number, Wait_class, sum(Rate_timewaited) Rate_timewaited_per_Class," + metric_save_mode +" " + //'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                "from( " +
                                     "select cast(min(sn.begin_interval_time) over(partition by sn.dbid, sn.snap_id) as date) snap_time, " + //--workaround to uniform snap_time over all instances in RAC
                                  "sn.snap_id, " +
                                    "sn.instance_number, " +
                                     "ss.event_name, " +
                                     "round((ss.time_waited_micro - lag(ss.time_waited_micro) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) / " +
                                      "(extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600 " +
                                             "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.event_id order by sn.snap_id nulls first)) * 3600 " + //--deals with daylight savings time change
                                             "+ extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60 " +
                                             "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_timewaited,Wait_class " + //--time_waited_microsec / clock_time_sec summed over instances 
                                    "from dba_hist_system_event ss, " +
                                       "dba_hist_snapshot sn " +
                                    "where " +
                                       "sn.snap_id = ss.snap_id " +
                                       "and sn.dbid = ss.dbid " +
                                       "and sn.instance_number = ss.instance_number " +
                                       "and sn.begin_interval_time " + delta_time_where_clause + " " +
                                       "and wait_class<>'Idle' " +
                                    "union all " +// --above is the calculation of wait events below is the calculation of CPU usage
                                   "select cast(min(sn.begin_interval_time) over(partition by sn.dbid, sn.snap_id) as date) snap_time, " +// --workaround to uniform snap_time over all instances in RAC
                                   "sn.snap_id, " +
                                   "sn.instance_number, " +
                                   "ss.stat_name event_name, " +
                                   "10000 * round((ss.value - lag(ss.value) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first)) / " +
                                                "(extract(hour from END_INTERVAL_TIME-begin_interval_time) * 3600 " +
                                                "- extract(hour from sn.snap_timezone -lag(sn.snap_timezone) over(partition by ss.dbid, ss.instance_number, ss.stat_id order by sn.snap_id nulls first)) * 3600 " + //--deals with daylight savings time change
                                                "+extract(minute from END_INTERVAL_TIME-begin_interval_time) * 60 " +
                                                "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_timewaited, " + //--rate CPU / elapsed time, converted to same units as wait events above
                                                "'CPU' Wait_class " +
                                    "from dba_hist_sysstat ss,dba_hist_snapshot sn " +
                                    "where " +
                                       "sn.snap_id = ss.snap_id " +
                                       "and sn.dbid = ss.dbid " +
                                       "and sn.instance_number = ss.instance_number " +
                                       "and sn.begin_interval_time " + delta_time_where_clause + " " +
                                       "and ss.stat_name = 'CPU used by this session'" + //-- I don't believe I need to add 'recursive cpu usage' and 'parse time cpu', at least not in 11gR2
                                ") group by snap_time, snap_id, instance_number, Wait_class";
                    
                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                   ConnectToSqllite();
                   SQLiteTransaction transaction = con.BeginTransaction();
                   {
                        try
                        {
                            foreach (DataRow row in oradt.Rows)
                            {
                                decimal mratetimewaitedperclass = 0;

                                if (row.IsNull("RATE_TIMEWAITED_PER_CLASS"))
                                {
                                    mratetimewaitedperclass = 0;
                                }
                                else
                                {
                                    mratetimewaitedperclass = Convert.ToDecimal(row[6]);
                                }

                                TSQL = "insert into tblWaitclass(" +
                                    "HOSTNAME,DBNAME,SNAP_TIME,SNAP_ID,INSTANCE_NUMBER,WAIT_CLASS,RATE_TIMEWAITED_PER_CLASS,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                    "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + "," + Convert.ToInt64(row[4]) + ",'" + Convert.ToString(row[5]) + "'," +
                                    "" + mratetimewaitedperclass + "," + Convert.ToInt64(row[7]) + "," + Convert.ToInt64(row[8]) + ",'" + Convert.ToString(row[9]) + "')";
                                SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                                sqlitecommand.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Waitclass Data found!.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception-->" + ex.Message);
                errorfound = true;

            }
            finally
            {
                conn.Close();
            }
        }

        public void iostatdetails()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME,cast(min(sn.begin_interval_time) over(partition by sn.dbid, sn.snap_id) as date) snap_time," + //--workaround to uniform snap_time over all instances in RAC
                                //" --ss.dbid,"+ //--uncomment if you have multiple dbid in your AWR " +
                                 "sn.instance_number, " +
                                 "io.function_name, " +
                                 "io.filetype_name, " +
                                    "round((io.small_read_reqs - lag(io.small_read_reqs) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first)) / " +
                                              "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                              "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first) )*3600  " +
                                              //"--deals with daylight savings time change " +
                                              "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                              "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_small_read_reqs, " +
                                    "round((io.large_read_megabytes - lag(io.large_read_megabytes) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first)) / " +
                                              "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                              "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first) )*3600  " +
                                              //"--deals with daylight savings time change " +
                                              "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                              "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_large_read_megabytes, " +
                                    "round((io.small_write_reqs - lag(io.small_write_reqs) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first)) / " +
                                              "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                              "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first) )*3600  " +
                                              //"--deals with daylight savings time change " +
                                              "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                              "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_small_write_reqs, " +
                                    "round((io.large_write_megabytes - lag(io.large_write_megabytes) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first)) / " +
                                              "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                              "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first) )*3600  " +
                                              //"--deals with daylight savings time change " +
                                              "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                              "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_large_write_megabytes, " +
                                    "round((io.wait_time - lag(io.wait_time) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first)) / " +
                                              "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                              "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by io.dbid,io.instance_number,io.function_name,io.filetype_name order by sn.snap_id nulls first) )*3600  " +
                                              //"--deals with daylight savings time change " +
                                              "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                              "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_wait_time, " +
                                              //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                              "" + metric_save_mode + " " +
                                "from dba_hist_iostat_detail io, " +
                                     "dba_hist_snapshot sn " +
                                "where " +
                                  "sn.snap_id = io.snap_id " +
                                 "and sn.dbid = io.dbid " +
                                 "and sn.instance_number = io.instance_number " +
                                 "and sn.begin_interval_time " + delta_time_where_clause + " " +
                                "order by sn.snap_id";

                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                            foreach (DataRow row in oradt.Rows)
                            {
                                decimal mRATE_SMALL_READ_REQS = 0;
                                decimal mRATE_LARGE_READ_MEGABYTES = 0;
                                decimal mRATE_SMALL_WRITE_REQS = 0;
                                decimal mRATE_LARGE_WRITE_MEGABYTES = 0;
                                decimal mRATE_WAIT_TIME = 0;

                                if (row.IsNull("RATE_SMALL_READ_REQS"))
                                {
                                    mRATE_SMALL_READ_REQS = 0;
                                }
                                else
                                {
                                    mRATE_SMALL_READ_REQS = Convert.ToDecimal(row[6]);
                                }

                                if (row.IsNull("RATE_LARGE_READ_MEGABYTES"))
                                {
                                    mRATE_LARGE_READ_MEGABYTES = 0;
                                }
                                else
                                {
                                    mRATE_LARGE_READ_MEGABYTES = Convert.ToDecimal(row[7]);
                                }

                                if (row.IsNull("RATE_SMALL_WRITE_REQS"))
                                {
                                    mRATE_SMALL_WRITE_REQS = 0;
                                }
                                else
                                {
                                    mRATE_SMALL_WRITE_REQS = Convert.ToDecimal(row[8]);
                                }

                                if (row.IsNull("RATE_LARGE_READ_MEGABYTES"))
                                {
                                    mRATE_LARGE_WRITE_MEGABYTES = 0;
                                }
                                else
                                {
                                    mRATE_LARGE_WRITE_MEGABYTES = Convert.ToDecimal(row[9]);
                                }

                                if (row.IsNull("RATE_WAIT_TIME"))
                                {
                                    mRATE_WAIT_TIME = 0;
                                }
                                else
                                {
                                    mRATE_WAIT_TIME = Convert.ToDecimal(row[10]);
                                }



                                TSQL = "insert into tblIOStatDetails(" +
                                    "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,FUNCTION_NAME,FILETYPE_NAME,RATE_SMALL_READ_REQS,RATE_LARGE_READ_MEGABYTES,RATE_SMALL_WRITE_REQS,RATE_LARGE_WRITE_MEGABYTES,RATE_WAIT_TIME,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                    "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "','" + Convert.ToString(row[5]) + "'," +
                                    "" + mRATE_SMALL_READ_REQS + "," + mRATE_LARGE_READ_MEGABYTES + "," + mRATE_SMALL_WRITE_REQS + "," + mRATE_LARGE_WRITE_MEGABYTES + "," + mRATE_WAIT_TIME + "," + Convert.ToInt64(row[11]) + "," + Convert.ToInt64(row[12]) + ",'" + Convert.ToString(row[13]) + "')";
                                SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                                sqlitecommand.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No IO Stats Data found!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->" + ex.Message);
                errorfound = true;
            }
            finally
            {
                conn.Close();
            }
        }

        public void iostatlatency()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME, cast(min(sn.begin_interval_time) over (partition by sn.dbid,sn.snap_id) as date) snap_time," +  //--workaround to uniform snap_time over all instances in RAC
                            // "--eh.dbid,"+  //--uncomment if you have multiple dbid in your AWR
                             "sn.instance_number," +
                             "eh.event_name," +
                             "eh.wait_time_milli," +
                             //"--eh.wait_count," +
                             "eh.wait_count - lag(eh.wait_count) over (partition by eh.dbid,eh.instance_number,eh.event_id,eh.wait_time_milli order by sn.snap_id nulls first) Delta_wait_count," +
                                    "round((eh.wait_count - lag(eh.wait_count) over (partition by eh.dbid,eh.instance_number,eh.event_id,eh.wait_time_milli order by sn.snap_id nulls first)) /" +
                                      "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600" +
                                          "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over" +
                                          "(partition by eh.dbid,eh.instance_number,eh.event_id,eh.wait_time_milli order by sn.snap_id nulls first) )*3600" +  //--deals with daylight savings time change
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_wait_count_per_bin," +
                                    "0.75 * eh.wait_time_milli * round((eh.wait_count - lag(eh.wait_count) over (partition by eh.dbid,eh.instance_number,eh.event_id,eh.wait_time_milli order by sn.snap_id nulls first)) /" +
                                      "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600" +
                                          "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over" +
                                          "(partition by eh.dbid,eh.instance_number,eh.event_id,eh.wait_time_milli order by sn.snap_id nulls first) )*3600" +  //--deals with daylight savings time change
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_wait_time_per_bin," +
                                          //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                          "" + metric_save_mode + " " +
                            "from dba_hist_event_histogram eh," +
                                 "dba_hist_snapshot sn " +
                            "where " +
                                "sn.snap_id = eh.snap_id " +
                            "and sn.dbid = eh.dbid " +
                            "and sn.instance_number = eh.instance_number " +
                            "and sn.begin_interval_time " + delta_time_where_clause + " " +
                            "and eh.wait_class in ('User I/O','System I/O','Commit') " +  //-- need to limit search or dump file can grow too big
                            "order by sn.snap_id";

                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                            foreach (DataRow row in oradt.Rows)
                            {
                                decimal mWAIT_TIME_MILLI = 0;
                                decimal mDELTA_WAIT_COUNT = 0;
                                decimal mRATE_WAIT_COUNT_PER_BIN = 0;
                                decimal mRATE_WAIT_TIME_PER_BIN = 0;

                                if (row.IsNull("WAIT_TIME_MILLI"))
                                {
                                    mWAIT_TIME_MILLI = 0;
                                }
                                else
                                {
                                    mWAIT_TIME_MILLI = Convert.ToDecimal(row[5]);
                                }

                                if (row.IsNull("DELTA_WAIT_COUNT"))
                                {
                                    mDELTA_WAIT_COUNT = 0;
                                }
                                else
                                {
                                    mDELTA_WAIT_COUNT = Convert.ToDecimal(row[6]);
                                }

                                if (row.IsNull("RATE_WAIT_COUNT_PER_BIN"))
                                {
                                    mRATE_WAIT_COUNT_PER_BIN = 0;
                                }
                                else
                                {
                                    mRATE_WAIT_COUNT_PER_BIN = Convert.ToDecimal(row[7]);
                                }

                                if (row.IsNull("RATE_WAIT_TIME_PER_BIN"))
                                {
                                    mRATE_WAIT_TIME_PER_BIN = 0;
                                }
                                else
                                {
                                    mRATE_WAIT_TIME_PER_BIN = Convert.ToDecimal(row[8]);
                                }

                                TSQL = "insert into tblIOStatLatency(" +
                                    "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,EVENT_NAME,WAIT_TIME_MILLI,DELTA_WAIT_COUNT,RATE_WAIT_COUNT_PER_BIN,RATE_WAIT_TIME_PER_BIN,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                    "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "'," +
                                    "" + mWAIT_TIME_MILLI + "," + mDELTA_WAIT_COUNT + "," + mRATE_WAIT_COUNT_PER_BIN + "," + mRATE_WAIT_TIME_PER_BIN + "," + Convert.ToInt64(row[9]) + "," + Convert.ToInt64(row[10]) + ",'" + Convert.ToString(row[11]) + "')";
                                SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                                sqlitecommand.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No IO Latency Stats Data found!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->" + ex.Message);
                errorfound = true;
            }
            finally
            {
                conn.Close();
            }
        }


        public void servicestat()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME, cast(min(sn.begin_interval_time) over (partition by sn.dbid,sn.snap_id) as date) snap_time," + //--workaround to uniform snap_time over all instances in RAC
                            //" --ss.dbid," +  //--uncomment if you have multiple dbid in your AWR
                             "sn.instance_number," +
                             "ss.service_name," +
                             "ss.stat_name," +
                             "ss.value," +
                             "ss.value - lag(ss.value) over (partition by ss.dbid,ss.instance_number,ss.stat_id,ss.service_name order by sn.snap_id nulls first) Delta_value," +
                             "extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600" +
                                          "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by ss.dbid,ss.instance_number,ss.stat_id,ss.service_name order by sn.snap_id nulls first) )*3600" + //--deals with daylight savings time change
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time) Delta_sec," +
                             "round((ss.value - lag(ss.value) over (partition by ss.dbid,ss.instance_number,ss.stat_id,ss.service_name order by sn.snap_id nulls first)) /" +
                                   "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600" +
                                          "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by ss.dbid,ss.instance_number,ss.stat_id,ss.service_name order by sn.snap_id nulls first) )*3600" + //--deals with daylight savings time change
                                          "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60" +
                                          "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_value," +
                                          //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                          "" + metric_save_mode + " " +
                            "from dba_hist_service_stat ss," +
                                 "dba_hist_snapshot sn " +
                            "where " +
                                "sn.snap_id = ss.snap_id " +
                            "and sn.dbid = ss.dbid " +
                            "and sn.instance_number = ss.instance_number " +
                            "and sn.begin_interval_time " + delta_time_where_clause + " " +
                            "order by sn.snap_id";

                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                            foreach (DataRow row in oradt.Rows)
                            {
                                decimal mVALUE = 0;
                                decimal mDELTA_VALUE = 0;
                                decimal mDELTA_SEC = 0;
                                decimal mRATE_VALUE = 0;

                                if (row.IsNull("VALUE"))
                                {
                                    mVALUE = 0;
                                }
                                else
                                {
                                    mVALUE = Convert.ToDecimal(row[6]);
                                }

                                if (row.IsNull("DELTA_VALUE"))
                                {
                                    mDELTA_VALUE = 0;
                                }
                                else
                                {
                                    mDELTA_VALUE = Convert.ToDecimal(row[7]);
                                }

                                if (row.IsNull("DELTA_SEC"))
                                {
                                    mDELTA_SEC = 0;
                                }
                                else
                                {
                                    mDELTA_SEC = Convert.ToDecimal(row[8]);
                                }

                                if (row.IsNull("RATE_VALUE"))
                                {
                                    mRATE_VALUE = 0;
                                }
                                else
                                {
                                    mRATE_VALUE = Convert.ToDecimal(row[9]);
                                }

                                TSQL = "insert into tblServiceStat(" +
                                    "HOSTNAME,DBNAME,SNAP_TIME,INSTANCE_NUMBER,SERVICE_NAME,STAT_NAME,VALUE,DELTA_VALUE,DELTA_SEC,RATE_VALUE,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                    "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + ",'" + Convert.ToString(row[4]) + "','" + Convert.ToString(row[5]) + "'," +
                                    "" + mVALUE + "," + mDELTA_VALUE + "," + mDELTA_SEC + "," + mRATE_VALUE + "," + Convert.ToInt64(row[10]) + "," + Convert.ToInt64(row[11]) + ",'" + Convert.ToString(row[12]) + "')";
                                SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                                sqlitecommand.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Service Stats Data found!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->" + ex.Message);
                errorfound = true;
            }
            finally
            {
                conn.Close();
            }
        }

        public void topevents()
        {
            string TSQL = "";
            try
            {
                string sql = "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME, cast(min(sn.begin_interval_time) over (partition by sn.dbid,sn.snap_id) as date) snap_time," +  //--workaround to uniform snap_time over all instances in RAC
                            "sn.snap_id," +
                              "sn.instance_number," +
                               "ss.event_name," +
                               "round((ss.time_waited_micro - lag(ss.time_waited_micro) over (partition by ss.dbid,ss.instance_number,ss.event_id order by sn.snap_id nulls first)) / " +
                               "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                      "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by ss.dbid,ss.instance_number,ss.event_id order by sn.snap_id nulls first) )*3600 " + //--deals with daylight savings time change
                                      "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                      "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_timewaited, " +  //-- time_waited_microsec/clock_time_sec summed over instances
                                      //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                      "" + metric_save_mode + " " +
                        "from   dba_hist_system_event ss," +
                               "dba_hist_snapshot sn," +
                               "( select ss.dbid,ss.instance_number,ss.event_id, " +
                                      "rank() over (partition by ss.dbid,ss.instance_number order by max(ss.time_waited_micro)-min(ss.time_waited_micro) desc) Waited_time_rank " +
                               "from dba_hist_system_event ss, " +
                                    "dba_hist_snapshot sn " +
                               "where " +
                                    "sn.snap_id = ss.snap_id " +
                                    "and sn.dbid = ss.dbid " +
                                    "and sn.instance_number = ss.instance_number " +
                                    "and sn.begin_interval_time " + delta_time_where_clause + " " +
                                    "and wait_class <>'Idle' " +
                               "group by ss.dbid,ss.instance_number,ss.event_id " +
                               ") rw " +  //-- this represents the ranked wait events by wait time
                        "where " +
                               "sn.snap_id = ss.snap_id " +
                               "and sn.dbid = ss.dbid " +
                               "and sn.instance_number = ss.instance_number " +
                               "and sn.begin_interval_time " + delta_time_where_clause + " " +
                               "and rw.dbid = ss.dbid " +
                               "and rw.instance_number = ss.instance_number " +
                               "and rw.event_id = ss.event_id " +
                               "and rw.Waited_time_rank<=5 " +      // -- top 5 wait events
                        "union all " +  //-- above is the calculation of wait events below is the calculation of CPU usage
                        "select '" + txthost.Text + "' as HOSTNAME,'" + txtservice.Text + "' as DBNAME,cast(min(sn.begin_interval_time) over (partition by sn.dbid,sn.snap_id) as date) snap_time, " +  //--workaround to uniform snap_time over all instances in RAC
                               "sn.snap_id, " +
                               "sn.instance_number, " +
                               "ss.stat_name event_name, " +
                               "10000* round((ss.value - lag(ss.value) over (partition by ss.dbid,ss.instance_number,ss.stat_id order by sn.snap_id nulls first)) / " +
                                      "(extract(hour from END_INTERVAL_TIME-begin_interval_time)*3600 " +
                                      "-extract(hour from sn.snap_timezone - lag(sn.snap_timezone) over (partition by ss.dbid,ss.instance_number,ss.stat_id order by sn.snap_id nulls first) )*3600 " + //--deals with daylight savings time change
                                      "+ extract(minute from END_INTERVAL_TIME-begin_interval_time)* 60 " +
                                      "+ extract(second from END_INTERVAL_TIME-begin_interval_time)),2 ) Rate_timewaited, " +  //-- rate CPU /elapsed time, converted to same units as wait events above
                                      //"'true' as ISBASEPOINT,'false' as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE " +
                                      "" + metric_save_mode + " " +
                                      "from dba_hist_sysstat ss," +
                             "dba_hist_snapshot sn " +
                        "where " +
                        "sn.snap_id = ss.snap_id " +
                        "and sn.dbid = ss.dbid " +
                        "and sn.instance_number = ss.instance_number " +
                        "and sn.begin_interval_time " + delta_time_where_clause + " " +
                        "and ss.stat_name='CPU used by this session'";

                ConnectDatabase();

                DataTable oradt = new DataTable();
                OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, conn);
                oraAdapt.Fill(oradt);
                if (oradt.Rows.Count > 0)
                {
                    ConnectToSqllite();
                    SQLiteTransaction transaction = con.BeginTransaction();
                    {
                        try
                        {
                            foreach (DataRow row in oradt.Rows)
                            {
                                decimal mRATE_TIMEWAITED = 0;

                                if (row.IsNull("RATE_TIMEWAITED"))
                                {
                                    mRATE_TIMEWAITED = 0;
                                }
                                else
                                {
                                    mRATE_TIMEWAITED = Convert.ToDecimal(row[6]);
                                }


                                TSQL = "insert into tblTopEvents(" +
                                    "HOSTNAME,DBNAME,SNAP_TIME,SNAP_ID,INSTANCE_NUMBER,EVENT_NAME,RATE_TIMEWAITED,ISBASEPOINT,ISSAVEPOINT,SAVEPOINT_DATE) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "'," +
                                    "'" + Convert.ToString(row[2]) + "'," + Convert.ToInt64(row[3]) + "," + Convert.ToInt64(row[4]) + ",'" + Convert.ToString(row[5]) + "'," +
                                    "" + mRATE_TIMEWAITED + "," + Convert.ToInt64(row[7]) + "," + Convert.ToInt64(row[8]) + ",'" + Convert.ToString(row[9]) + "')";
                                SQLiteCommand sqlitecommand = new SQLiteCommand(TSQL, con);
                                sqlitecommand.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception Excon)
                        {
                            MessageBox.Show(TSQL + "Exception-->" + Excon.Message);
                            transaction.Rollback();
                            errorfound = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No top five wait events Data found!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TSQL + "Exception-->" + ex.Message);
                errorfound = true;
            }
            finally
            {
                conn.Close();
            }
        }

        private void bttnBasePoint_Click(object sender, EventArgs e)
        {
           tv.Enabled = false;
           metric_save_mode = "1 as ISBASEPOINT,0 as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE ";
           getsnapdates();
           get_savepointsdate();
        }

        private void tv_Click(object sender, EventArgs e)
        {
            HighlightCheckedNodes();
        }

        private void bttnSavePoint_Click(object sender, EventArgs e)
        {
            tv.Enabled = false;
            metric_save_mode = "0 as ISBASEPOINT,1 as ISSAVEPOINT,'" + DateTime.Now + "' as SAVEPOINT_DATE ";
            getsnapdates();
            get_savepointsdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bttnCompare_Click(object sender, EventArgs e)
        {
            tv.Enabled = true;
            tv.Focus();
            get_savepointsdate();
        }

        private void dgsavept_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("cell selected: '" + dgsavept.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() +"'");
            }
        }
    }
}
