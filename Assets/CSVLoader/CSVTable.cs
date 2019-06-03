using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CSVTable 
{

	// 表头
	private List<string> m_headers = new List<string>();
    // 数据类型
    private List<string> m_dataType = new List<string>();
	// 表数据
	private List<CSVRecord> m_records = new List<CSVRecord>();

    

    public List<string> Headers
	{
		get
		{
			return m_headers;
		}
	}
    public List<string> DataTypes
    {
        get
        {
            return m_dataType;
        }
    }
    public List<CSVRecord> Records
	{
		get
		{
			return m_records;
		}
	}
	
	public CSVTable ()
	{
		this.Initialize();
	}
	
	public void Initialize ()
	{
	}
	
	public void Execution ()
	{
	}
	
	public void AddHeaders (string t_header)
	{
		m_headers.Add(t_header);
	}
    public void AddDataType(string dt)
    {
        m_dataType.Add(dt);
    }
    public void AddRecord (CSVRecord t_record)
	{
		m_records.Add(t_record);
	}
	
	public CSVRecord GetRecord (int t_record_number)
	{
		return m_records[t_record_number];
	}
}



