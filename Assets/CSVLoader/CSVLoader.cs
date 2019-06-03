using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class CSVLoader 
{
	public CSVTable LoadCSV(TextAsset csvAsset)
	{
		return LoadCSVFromContent(csvAsset.text);
	}

	public static CSVTable LoadCSV (string t_csv_path)
	{
		TextAsset csvTextAsset = Resources.Load(t_csv_path) as TextAsset;
		return LoadCSVFromContent(csvTextAsset.text);
	}

	private static CSVTable LoadCSVFromContent(string csvContent)
	{
		CSVTable csvTable = new CSVTable();
		string csvText = csvContent.Replace(Environment.NewLine, "\r");
		csvText = csvText.Trim('\r');
		csvText = csvText.Replace ("\r\r","\r");

		string[] csv = csvText.Split('\r');
		List<string> rows = new List<string>(csv);
		// 添加表头
		string[] headers = rows[0].Split(',');
		foreach (string header in headers)
		{
			csvTable.AddHeaders(header);
		}
		rows.RemoveAt(0);
        // 添加列的数据类型
        string[] dataTypes = rows[0].Split(',');
        foreach (string dt in dataTypes)
        {
            csvTable.AddDataType(dt);
        }
        rows.RemoveAt(0);

        // 添加行数据
		foreach (string row in rows)
		{
			string[] fields = row.Split(',');
			csvTable.AddRecord(CreateRecord(headers, fields));
		}
		return csvTable;
	}
	
	private static CSVRecord CreateRecord (string[] t_headers, string[] t_fields)
	{
		CSVRecord record = new CSVRecord();
		for (int i = 0; i < t_headers.Length; ++i)
		{
			record.AddField(t_headers[i], t_fields[i]);
		}
		return record;
	}
}


