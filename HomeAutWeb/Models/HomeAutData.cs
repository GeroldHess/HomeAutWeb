using System.Data;

namespace HomeAutWeb.Models;

public class TempValue
{
    public Int64 ID {get;set;}
    public DateTime insertedon {get;set;}
    public decimal Temperatur {get;set;}
    public int Status {get;set;}
    public string Geraet {get;set;}

    public TempValue(Int64 ID_,DateTime insertedon_,decimal Temperatur_,int Status_,string Geraet_)
    {
        this.ID = ID_;
        this.insertedon = insertedon_;
        this.Temperatur = Temperatur_;
        this.Status = Status_;
        this.Geraet = Geraet_;
    }

    public TempValue(IDataReader Reader)
    {
        this.ID = System.Convert.ToInt64(Reader["ID"]);
        this.insertedon = System.Convert.ToDateTime(Reader["insertedon"]);
        this.Geraet = Reader["Geraet"].ToString();
        this.Status = 0;
        this.Temperatur = System.Convert.ToDecimal(Reader["Temperatur"]);
    }
}