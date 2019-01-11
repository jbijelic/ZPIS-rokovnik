﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Kalendar
{
    /// <summary>
    /// za display 
    /// </summary>
    public class Napomena : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //public DateTime Datum { get; set; }
        //public string Naziv { get; set; }
        //public string Opis { get; set; }
        //public bool Vidljivo { get; set; } = false;

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                SetValue(ref datum, value);
                OnPropertyChanged(nameof(datum));
            }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                SetValue(ref naziv, value);
                OnPropertyChanged(nameof(naziv));
            }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set
            {
                SetValue(ref opis, value);
                OnPropertyChanged(nameof(opis));
            }
        }

        private bool vidljivo;

        public bool Vidljivo
        {
            get { return vidljivo; }
            set
            {
                SetValue(ref vidljivo, value);
                OnPropertyChanged(nameof(vidljivo));
            }
        }


        public Napomena()
        {
        }

        public Napomena(DateTime datum, string naziv, string opis)
        {
            this.Datum = datum;
            this.Naziv = naziv;
            this.Opis = opis;
        }

    }
}
