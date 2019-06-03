﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVCodeConfig 
{
	public static string DataClassFormat = @"public class {0}
{{
{1}}}";

	//如果是带Vector3或者Vector3类型的数据需要使用带有UnityEngiine命名空间
	public static string DataClassNameSpaceFormat = @"
using UnityEngine;

public class {0}
{{
{1}
}}";

	public static string FieldFormat = "\tpublic {0} {1} {{ set; get; }}";

	public static string ClassNameFormat = "{0}Model";

	public static string ModelListPrivateStatementFormat = "private List<{0}> {1}";

	public static string ModelListPublicPropertyFormat = @"
public List<{0}> {1}
{{
	get
	{{
		if({2} == null)
		{{
			{3}();
		}}
		return {4};
	}}
}}";

	public static string parseMethodNameFormat = "Init{0}";
	public static string methodFormat = "{0}();";
	public static string ModelDataParseMethodFormat = @"
private void {0}()
{{
	{1} = new List<{2}>;
	string path = DEFAULT_CSV_PATH + {3};
	CSVTable csvTable = CsvLoader.LoadCSV(path);
	foreach (CSVRecord record in csvTable.Records)
	{{
		{4} temp = new {5}();
		foreach (string header in csvTable.Headers)
		{{
                try{{
			        {6}
                }}catch(Exception e)
                {{
                    Debug.LogError(""第"" + csvTable.Records.IndexOf(record) + ""行"" + csvTable.Headers.IndexOf(header) + ""列解析报错，列名："" + header + "" 数据："" + record.GetField(header));
                }}
		}}
		{7}.Add(temp);
	}}
}}";

	public static string ModelDataHeaderEqualFormat_1 = @"if (string.Equals(header, {0}))
			{{
				{1}
			}}";

	public static string ModelDataHeaderEqualFormat_2 = @"
			else if (string.Equals(header, {0}))
			{{
				{1}
			}}";
	
	public static string ModelDataFieldValuationFormat_String = "temp.{0} = record.GetField(header);";
	public static string ModelDataFieldValuationFormat_Int = "temp.{0} = ConvertUtil.Str2Int(record.GetField(header));";
	public static string ModelDataFieldValuationFormat_Double = "temp.{0} = ConvertUtil.Str2Double(record.GetField(header));";
	public static string ModelDataFieldValuationFormat_Bool = "temp.{0} = ConvertUtil.Str2Int(record.GetField(header)) != 0;";
	public static string ModelDataFieldValuetionFormat_Color = @"Color c = Color.white;
				string colorStr = record.GetField(header);
				ColorUtility.TryParseHtmlString(colorStr,out c);
				temp.{0} = c;";
}
