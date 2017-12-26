/*--------------------UAS/GASAL/2017/2018---------------------*
 * NIM   : 1512502707             |   FAKULTAS   : FTI / SI   *
 * NAMA  : ZACKY BURHANI HOTIB    |   MATAKULIAH : ASP.NET    *
 * KELP. : SI                     |   TGL. UTS   : 27/12/17   *
 *------------------------------------------------------------*/

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;


public class clsKereta
{
    /// <summary>
    /// </summary>
    private List<clsItemKereta> PKeretaBelanja;

    public clsKereta()
    {
        PKeretaBelanja = new List<clsItemKereta>();
    }

    public int Counter
    {
        get
        {
            return PKeretaBelanja.Count;
        }
        set
        {
        }
    }

    public void AddItems(string _KdBrg, string _NmBrg, double _HrgBrg, int _JmlBrg)
    {
        bool barang_ada = false;
        foreach (clsItemKereta item in PKeretaBelanja)
        {
            if (item.PKdBrg == _KdBrg)
            {
                item.PJmlBrg += 1;
                barang_ada = true;
            }
        }
        if(!barang_ada)
        {
            var item = new clsItemKereta(_KdBrg, _NmBrg, _HrgBrg, 1);
            PKeretaBelanja.Add(item);
        }
    }

    public void DeleteItem(int _Index)
    {
        PKeretaBelanja.RemoveAt(_Index);
    }

    public List<clsItemKereta> GetItems()
    {
        return PKeretaBelanja;
    }

    public void UpdateQty(int _Index, int _JmlBrg)
    {
        clsItemKereta item;
        item = PKeretaBelanja[_Index];
        item.PJmlBrg = _JmlBrg;
    }
}
