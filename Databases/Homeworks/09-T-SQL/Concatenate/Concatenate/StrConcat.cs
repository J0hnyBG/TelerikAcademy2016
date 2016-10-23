using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

using Microsoft.SqlServer.Server;

[Serializable]
[SqlUserDefinedAggregate(
    Format.UserDefined, 
    IsInvariantToNulls = true, 
    IsInvariantToDuplicates = false,
    IsInvariantToOrder = false, 
    MaxByteSize = 8000, 
    Name = "Concatenate")]
public class StrConcat : IBinarySerialize
{
    private StringBuilder _intermediateResult;

    internal string IntermediateResult
    {
        get { return this._intermediateResult.ToString(); }
    }

    public void Read(BinaryReader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException("reader");
        }

        this._intermediateResult = new StringBuilder(reader.ReadString());
    }

    public void Write(BinaryWriter writer)
    {
        if (writer == null)
        {
            throw new ArgumentNullException("writer");
        }

        writer.Write(this._intermediateResult.ToString());
    }

    public void Init()
    {
        this._intermediateResult = new StringBuilder();
    }

    public void Accumulate(SqlString value)
    {
        if (value.IsNull)
        {
            return;
        }

        this._intermediateResult.Append(value.Value + ", ");
    }

    public void Merge(StrConcat other)
    {
        if (null == other)
        {
            return;
        }

        this._intermediateResult.Append(other._intermediateResult + ", ");
    }

    public SqlString Terminate()
    {
        var output = string.Empty;

        if (this._intermediateResult != null && this._intermediateResult.Length > 0)
        {
            output = this._intermediateResult.ToString(0, this._intermediateResult.Length - 1);
        }

        return new SqlString(output);
    }
}
