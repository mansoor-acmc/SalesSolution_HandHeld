using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using SalesDelivery.WebRefSales;
using SalesDelivery.WebRefDeviceOps;
using System.Net;

namespace SalesDelivery
{
    public class DBClass
    {
        SqlCeConnection _connection;

        public DBClass()
        {
            InitConnection();
        }

        void InitConnection()
        {
            _connection = new SqlCeConnection();
            _connection.ConnectionString = ("Data Source ="
                        + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                        + ("\\SalesOrderDB.sdf;"
                        + ("Password =" + "\"111111\";"))));
        }

        public bool ShrinkDatabase()
        {
            try
            {
                SqlCeEngine engine = new SqlCeEngine(_connection.ConnectionString);

                engine.Compact(_connection.ConnectionString);
                engine.Shrink();
            }
            catch (Exception exp)
            {
                string msg = exp.Message;
                return false;
            }
            return true;
        }


        public bool DeleteOldData()
        {
            DateTime dtOld = DateTime.Now.AddDays(-20);
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM PalletInfo WHERE DateScanned < @p1;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.DateTime);
                cmd.Parameters["@p1"].Value = dtOld;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                {
                    sqlString = "DELETE FROM LoginInfo WHERE LoginDate < @p1;";
                    cmd = new SqlCeCommand();
                    cmd.Parameters.Add("@p1", SqlDbType.DateTime);
                    cmd.Parameters["@p1"].Value = dtOld;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;

                    if (this._connection.State != ConnectionState.Open)
                        this._connection.Open();

                    rowsEffected = cmd.ExecuteNonQuery();
                    if (rowsEffected > 0)
                    {
                        dtOld = DateTime.Now.AddDays(-1);
                        sqlString = "DELETE FROM DeviceMessage WHERE MsgDate < @p1;";
                        cmd = new SqlCeCommand();
                        cmd.Parameters.Add("@p1", SqlDbType.DateTime);
                        cmd.Parameters["@p1"].Value = dtOld;

                        cmd.CommandText = sqlString;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = this._connection;

                        if (this._connection.State != ConnectionState.Open)
                            this._connection.Open();

                        rowsEffected = cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        public DataTable LoadPickedPallets(string pickingId, string itemId, string grade, long lineRecId)
        {
            DataTable dt = new DataTable("PalletInfo");

            string sqlString = "SELECT * FROM PalletInfo WHERE PickingListId=@p1 AND ItemId=@p2 AND Grade=@p3";
            
            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

                cmd.Parameters["@p1"].Value = pickingId;
                cmd.Parameters["@p2"].Value = itemId;
                cmd.Parameters["@p3"].Value = grade;

                if (lineRecId > 0)
                {
                    sqlString += " AND LineRecId=@p4";
                    cmd.Parameters.Add("@p4", SqlDbType.BigInt);
                    cmd.Parameters["@p4"].Value = lineRecId;
                }
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                adapter.Fill(dt);
                
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }

        public DataTable CheckRedundantPallets(string packingListId, string itemId, string pallets)
        {
            DataTable dt = new DataTable("PalletInfo");

            string sqlString = "SELECT * FROM PalletInfo WHERE PickingListId='" + packingListId + "' AND ItemId='"+itemId+"'";
            if (!string.IsNullOrEmpty(pallets))
            {
                sqlString += " AND PalletID NOT IN (" + pallets + ")";
            }
            sqlString += ";";

            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            try
            {
                //cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@p2", SqlDbType.NVarChar);

                //cmd.Parameters["@p1"].Value = packingListId;
                //cmd.Parameters["@p2"].Value = pallets;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                adapter.Fill(dt);

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }

        public DataTable LoadPallet(string palletId, string packingListId)
        {
            DataTable dt = new DataTable("PalletInfo");

            string sqlString = "SELECT * FROM PalletInfo WHERE PalletID=@p1 AND PickingListId=@p2;";
            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);

                cmd.Parameters["@p1"].Value = palletId;
                cmd.Parameters["@p2"].Value = packingListId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                adapter.Fill(dt);

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }

        public bool DeletePallet(string palletId, string pickingId)
        {
            string sqlString = "DELETE FROM PalletInfo WHERE PalletId=@p1 AND PickingListId=@p2;";
            SqlCeCommand cmd = new SqlCeCommand();

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                                
                cmd.Parameters["@p1"].Value = palletId;
                cmd.Parameters["@p2"].Value = pickingId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }

            return false;
        }

        

        public bool DeletePalletsRedundant(string pickingId, string pallets, bool isDel)
        {
            string sqlString = "DELETE FROM PalletInfo WHERE PickingListId='" + pickingId + "' ";
            if (!isDel)
                sqlString = "UPDATE PalletInfo SET Qty=0, IsReserved=0, IsAvailable=0 WHERE PickingListId='" + pickingId + "' ";
            if (!string.IsNullOrEmpty(pallets))
            {
                sqlString += " AND PalletId IN (" + pallets + ")";
            }
            sqlString += ";";

            SqlCeCommand cmd = new SqlCeCommand();

            try
            {
                //cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                //cmd.Parameters.Add("@p2", SqlDbType.NVarChar);

                //cmd.Parameters["@p1"].Value = pickingId;
                //cmd.Parameters["@p2"].Value = pallets;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }

            return false;
        }


        public bool UpdatePallet(SalesLine pallet, string pickingId, DateTime dateScanned, bool isReserved, bool isAvailable, 
            int recType, bool isManual)
        {
            string sqlString = "SELECT * FROM PalletInfo WHERE PickingListId=@p1 AND PalletId=@p2;";
            SqlCeCommand cmd = new SqlCeCommand();

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);


                cmd.Parameters["@p1"].Value = pickingId;
                cmd.Parameters["@p2"].Value = pallet.SerialNumber;
                

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    sqlString = "UPDATE PalletInfo SET  IsReserved=@p2, Remarks=@p3, IsAvailable=@p6, Qty=@p7, Grade=@p8, "+
                        "SQMPallet=@p9,HalfPallet=@p10, Size=@p11, Color=@p12, RecType=@p13, LineRecId=@p14, IsManual=@p15 WHERE PalletID=@p4 AND PickingListId=@p5";
                    cmd = new SqlCeCommand();

                    //cmd.Parameters.Add("@p1", SqlDbType.DateTime);
                    cmd.Parameters.Add("@p2", SqlDbType.Bit);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p4", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p6", SqlDbType.Bit);
                    cmd.Parameters.Add("@p7", SqlDbType.Decimal);
                    cmd.Parameters.Add("@p8", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p9", SqlDbType.Decimal);
                    cmd.Parameters.Add("@p10", SqlDbType.Bit);
                    cmd.Parameters.Add("@p11", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p12", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p13", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@p14", SqlDbType.BigInt);
                    cmd.Parameters.Add("@p15", SqlDbType.Bit);

                    //cmd.Parameters["@p1"].Value = DateTime.Now;
                    cmd.Parameters["@p2"].Value = isReserved;
                    cmd.Parameters["@p3"].Value = pallet.Remarks;
                    cmd.Parameters["@p4"].Value = pallet.SerialNumber;
                    cmd.Parameters["@p5"].Value = pickingId;
                    cmd.Parameters["@p6"].Value = isAvailable;
                    cmd.Parameters["@p7"].Value = pallet.SalesQty.HasValue?pallet.SalesQty.Value:0;
                    cmd.Parameters["@p8"].Value = pallet.Grade;
                    cmd.Parameters["@p9"].Value = pallet.SalesQtySQM.HasValue?pallet.SalesQtySQM.Value:0;
                    cmd.Parameters["@p10"].Value = pallet.IsHalfPallet;
                    cmd.Parameters["@p11"].Value = pallet.Size;
                    cmd.Parameters["@p12"].Value = pallet.Color;
                    cmd.Parameters["@p13"].Value = recType;
                    cmd.Parameters["@p14"].Value = pallet.LineRecId > 0 ? pallet.LineRecId : 0;
                    cmd.Parameters["@p15"].Value = isManual;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;

                    if (this._connection.State != ConnectionState.Open)
                        this._connection.Open();

                    int rowEffected = cmd.ExecuteNonQuery();
                }
                else
                {
                    sqlString = "INSERT INTO PalletInfo (PalletId, SalesId, ItemId, DateScanned, PickingListId, UpdatedBy, IsReserved, Remarks, Device, IsAvailable, Qty, Grade, SQMPallet, HalfPallet, Size, Color, RecType, LineRecId, IsManual) " +
                        "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19);";

                    cmd = new SqlCeCommand();

                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p4", SqlDbType.DateTime);
                    cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p6", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p7", SqlDbType.Bit);
                    cmd.Parameters.Add("@p8", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p9", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p10", SqlDbType.Bit);
                    cmd.Parameters.Add("@p11", SqlDbType.Decimal);
                    cmd.Parameters.Add("@p12", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p13", SqlDbType.Decimal);
                    cmd.Parameters.Add("@p14", SqlDbType.Bit);
                    cmd.Parameters.Add("@p15", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p16", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p17", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@p18", SqlDbType.BigInt);
                    cmd.Parameters.Add("@p19", SqlDbType.Bit);

                    cmd.Parameters["@p1"].Value = pallet.SerialNumber;
                    cmd.Parameters["@p2"].Value = pallet.SalesId;
                    cmd.Parameters["@p3"].Value = string.IsNullOrEmpty(pallet.ItemId)==false ? pallet.ItemId : string.Empty;
                    cmd.Parameters["@p4"].Value = dateScanned;
                    cmd.Parameters["@p5"].Value = pickingId;
                    cmd.Parameters["@p6"].Value = AppVariables.UpdatedBy;
                    cmd.Parameters["@p7"].Value = isReserved;
                    cmd.Parameters["@p8"].Value = pallet.Remarks;
                    cmd.Parameters["@p9"].Value = AppVariables.DeviceName;
                    cmd.Parameters["@p10"].Value = isAvailable;
                    cmd.Parameters["@p11"].Value = pallet.SalesQty.HasValue?pallet.SalesQty.Value:0;
                    cmd.Parameters["@p12"].Value = string.IsNullOrEmpty(pallet.Grade)==false?pallet.Grade:string.Empty;
                    cmd.Parameters["@p13"].Value = pallet.SalesQtySQM.HasValue?pallet.SalesQtySQM.Value:0;
                    cmd.Parameters["@p14"].Value = pallet.IsHalfPallet;
                    cmd.Parameters["@p15"].Value = string.IsNullOrEmpty(pallet.Size)==false?pallet.Size:string.Empty;
                    cmd.Parameters["@p16"].Value = string.IsNullOrEmpty(pallet.Color) == false ? pallet.Color : string.Empty;
                    cmd.Parameters["@p17"].Value = recType;
                    cmd.Parameters["@p18"].Value = pallet.LineRecId > 0 ? pallet.LineRecId : 0;
                    cmd.Parameters["@p19"].Value = isManual;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;

                    if (this._connection.State != ConnectionState.Open)
                        this._connection.Open();

                    int rowEffected=cmd.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }

            return false;
        }

        public void FillDropdowns()
        {
            SalesService client = new SalesService();

            if (AppVariables.FGLoadingLines == null)
                client.BeginGetFGLines(new AsyncCallback(FGLoadingLinesInfo), client);
        }

        static void FGLoadingLinesInfo(IAsyncResult result)
        {
            SalesService client = (SalesService)result.AsyncState;
            try
            {
                if (result.IsCompleted)
                {
                    var items = client.EndGetFGLines(result);
                    if (items != null && items.Count() > 0)
                        AppVariables.FGLoadingLines = items.ToList();
                }
            }
            catch (Exception exp)
            {
                new DBClass().SubmitMessage(exp.Message, "FGLoadingLinesInfo", exp.StackTrace);

            }
        }

        #region   User Management  
        public UserInfo CheckLogin(string userName, string password)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT * FROM Users WHERE UserName=@p1 AND Password=@p2;";

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);

                cmd.Parameters[0].Value = userName;
                cmd.Parameters[1].Value = password;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    UserInfo info = new UserInfo()
                    {
                        UserId = int.Parse(dr["UserId"].ToString()),
                        UserName = dr["UserName"].ToString(),
                        Role = dr["Role"].ToString()
                    };
                    sqlString = "INSERT INTO LoginInfo (Username, LoginDate, DeviceName) Values (@p1, @p2, @p3);";
                    cmd = new SqlCeCommand();
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.DateTime);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

                    cmd.Parameters[0].Value = userName;
                    cmd.Parameters[1].Value = DateTime.Now;
                    cmd.Parameters[2].Value = AppVariables.DeviceName;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;
                    cmd.ExecuteNonQuery();

                    return info;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return null;
        }

        public DataTable AllUsers()
        {
            DataTable dt = new DataTable("Users");

            string sqlString = "SELECT * FROM Users";

            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                da.Fill(dt);
            }
            finally
            {
                this._connection.Close();
            }

            return dt;
        }

        public bool DeleteUser(int userId)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Users WHERE UserId = @p1;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int);
                cmd.Parameters["@p1"].Value = userId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        public bool InsertBulkUsers(List<UserInfo> users)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Users;";
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                {
                    foreach (UserInfo user in users)
                    {
                        ChangeUserInfo(user);
                    }
                    return true;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        public bool ChangeUserInfo(UserInfo user)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "";
            try
            {
                if (user.UserId.Equals(0))
                {
                    sqlString = "INSERT INTO Users (UserName, Password, Role) VALUES (@p1, @p2, @p3)";
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

                    cmd.Parameters["@p1"].Value = user.UserName;
                    cmd.Parameters["@p2"].Value = user.Password;
                    cmd.Parameters["@p3"].Value = user.Role;
                }
                else
                {
                    sqlString = "UPDATE Users SET UserName=@p1, Password=@p2, Role=@p3 WHERE UserId=@p4;";
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p4", SqlDbType.Int);

                    cmd.Parameters["@p1"].Value = user.UserName;
                    cmd.Parameters["@p2"].Value = user.Password;
                    cmd.Parameters["@p3"].Value = user.Role;
                    cmd.Parameters["@p4"].Value = user.UserId;
                }

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        #endregion


        #region App Settings  

        public string GetSettings(Option option)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string returnStr = string.Empty;

            string sqlString = "SELECT top (1) * FROM Options;";
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                SqlCeDataReader result = cmd.ExecuteReader();
                if (result != null && result.Read())
                {
                    if (option == Option.WithoutInternet)
                        returnStr = result["WithoutInternet"].ToString();                    
                }
            }
            finally
            {
                this._connection.Close();
            }
            return returnStr;
        }

        public bool SaveSettings(Option option, string value)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "UPDATE Options SET ";
            try
            {
                if (option == Option.WithoutInternet)
                {
                    sqlString += "WithoutInternet = @p1";
                    cmd.Parameters.Add("@p1", SqlDbType.Bit);
                    cmd.Parameters["@p1"].Value =bool.Parse(value);
                }                

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return true;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        #endregion

        #region Device Messages Ops

        public static bool CheckInternet()
        {
            bool connected;
            //string NetworkDefaultIP = "127.0.0.1";
            try
            {
                //IPHostEntry thisHost = Dns.GetHostEntry(AppVariables.DeviceName);
                //string localIpAddress = thisHost.AddressList[0].ToString();

                //connected = localIpAddress != IPAddress.Parse(NetworkDefaultIP).ToString();
                connected = Microsoft.WindowsMobile.Status.SystemState.WiFiStateConnected &&
                    Microsoft.WindowsMobile.Status.SystemState.ConnectionsCount>0;
            }
            catch (Exception)
            {
                connected = false;
            }

            return connected;
        }     

        public void SubmitMessage(string message, string methodName, string parameters)
        {
            DeviceMessage msg = new DeviceMessage()
            {
                Message = message,
                MethodName = methodName,
                DeviceName = string.IsNullOrEmpty(AppVariables.DeviceName) ? "" : AppVariables.DeviceName,
                Username = string.IsNullOrEmpty(AppVariables.UpdatedBy) ? "" : AppVariables.UpdatedBy,
                Parameters = parameters,
                DateOccur = DateTime.Now,
                DateOccurSpecified = true,
                DeviceIP = AppVariables.DeviceIP,
                ProjectName = AppVariables.ProjectName,
                IsSavedSpecified = false
            };
            
            /*if (DBClass.CheckInternet()) //If network is ready.
            {
                DeviceOps client = new DeviceOps();
                client.BeginSaveMessage(msg, new AsyncCallback(DeviceMsgCallback), client);
            }
            else    //If Network is OFF then save in DB and later send it to server.
            {*/
                MessageDevice(msg, true);
            //}
        }

        static void DeviceMsgCallback(IAsyncResult result)
        {
            DeviceOps client = (DeviceOps)result.AsyncState;
            try
            {
                bool isSaveMsgResult = false, isPinged = false;
                if (client != null && result.IsCompleted)
                {
                    client.EndSaveMessage(result, out isSaveMsgResult, out isPinged);
                }
            }            
            catch (Exception exp)
            {
                new DBClass().SubmitMessage(exp.Message, "DeviceMsgCallback", exp.StackTrace);
                
                //MessageBox.Show(exp.Message);
            }
        }
        public bool MessageDevice(DeviceMessage message, bool closeConn)
        {            
            try
            {
                string sqlString = "INSERT INTO DeviceMessage (Username, DeviceName, MsgDate, DeviceIP, Message, MethodName, Parameter, IsSent) " +
                    "VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8);";

                SqlCeCommand cmd = new SqlCeCommand();

                cmd.Parameters.Add("@p1", SqlDbType.NVarChar,50);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar,50);
                cmd.Parameters.Add("@p3", SqlDbType.DateTime);
                cmd.Parameters.Add("@p4", SqlDbType.NVarChar,30);
                cmd.Parameters.Add("@p5", SqlDbType.NVarChar,1000);
                cmd.Parameters.Add("@p6", SqlDbType.NVarChar,100);
                cmd.Parameters.Add("@p7", SqlDbType.NVarChar, 4000);
                cmd.Parameters.Add("@p8", SqlDbType.Bit);

                cmd.Parameters["@p1"].Value = message.Username;
                cmd.Parameters["@p2"].Value = message.DeviceName;
                cmd.Parameters["@p3"].Value = message.DateOccur;
                cmd.Parameters["@p4"].Value = AppVariables.DeviceIP;
                cmd.Parameters["@p5"].Value = message.Message;
                cmd.Parameters["@p6"].Value = message.MethodName;
                cmd.Parameters["@p7"].Value = message.Parameters;
                cmd.Parameters["@p8"].Value = false;

                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlString;

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
            }
            finally
            {
                if (closeConn)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }
            }

            return false;
        }

        public bool SendMessagesAgain()
        {
            List<DeviceMessage> messages = new List<DeviceMessage>();

            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT top (25) * FROM DeviceMessage WHERE IsSent=@p1 ORDER BY MsgDate;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.Bit);                
                cmd.Parameters["@p1"].Value = false;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DeviceMessage message = new DeviceMessage()
                    {
                        DeviceName = dr["DeviceName"].ToString(),
                        Username = dr["UserName"].ToString(),
                        DateOccur = DateTime.Parse(dr["MsgDate"].ToString()),
                        DateOccurSpecified = true,
                        Message = dr["Message"].ToString(),
                        MethodName = dr["MethodName"].ToString(),
                        DeviceIP = AppVariables.DeviceIP,
                        ProjectName = AppVariables.ProjectName,
                        Parameters = dr["Parameter"].ToString(),
                        ID = long.Parse(dr["ID"].ToString()),
                        IDSpecified = true
                    };
                    messages.Add(message);
                }
            }
            finally
            {
                this._connection.Close();
            }

            if (messages.Count > 0)
            {
                DeviceOps client = new DeviceOps();
                client.BeginSaveMessages(messages.ToArray(), new AsyncCallback(DeviceMessagesCallback), client);
            }
            return true;
        }
        static void DeviceMessagesCallback(IAsyncResult result)
        {
            DeviceOps client = (DeviceOps)result.AsyncState;
            try
            {
                if (client != null && result.IsCompleted)
                {
                    var messages = client.EndSaveMessages(result);
                    if (messages != null && messages.Count() > 0)
                    {
                        DBClass db = new DBClass();
                        foreach (DeviceMessage message in messages)
                        {
                            db.UpdateMessage(message, false);
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                //new DBClass().SubmitMessage(exp.Message, "DeviceMessagesCallback", exp.StackTrace);

                string exp1 = exp.Message;
            }
            finally
            {
                client.Dispose();
            }
        }

        public bool UpdateMessage(DeviceMessage message, bool closeConn)
        {
            try
            {
                string sqlString = "UPDATE DeviceMessage SET IsSent=@p1 WHERE ID=@p2;";
                SqlCeCommand cmd = new SqlCeCommand();

                cmd.Parameters.Add("@p1", SqlDbType.Bit);
                cmd.Parameters.Add("@p2", SqlDbType.BigInt);

                cmd.Parameters["@p1"].Value = true;
                cmd.Parameters["@p2"].Value = message.ID;

                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlString;

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
            }
            finally
            {
                if (closeConn)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }
            }

            return false;
        }
        #endregion
    }
}
