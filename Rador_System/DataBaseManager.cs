using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class DataBaseManager
{
    MySqlConnection mySqlConnection;

    public MySqlCommand _sqlCommand = null;
    public MySqlDataReader _sqlDataReader = null;

    string SQL_IP;
    string SQL_DB;
    string SQL_ID;
    string SQL_PW;

    public MySqlConnection myConnection
    {
        get
        {
            return mySqlConnection;
        }

        set
        {
            mySqlConnection = value;
        }
    }

    public DataBaseManager(string ip, string db, string id, string pw)
    {
        SQL_IP = ip;
        SQL_DB = db;
        SQL_ID = id;
        SQL_PW = pw;
    }

    public bool Connect()
    {
        string connect = string.Format($"Server={SQL_IP};Database={SQL_DB};Uid={SQL_ID};Pwd={SQL_PW};allow user variables=true;Connect Timeout=7200");

        myConnection = new MySqlConnection(connect);
        myConnection.Open();
        var cmd = new MySqlCommand();
        cmd.Connection = myConnection;

        // 연결 성공 시 true, 실패 시 false 반환
        if (myConnection.State == ConnectionState.Open)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Close()
    {
        myConnection.Close();
    }

}

