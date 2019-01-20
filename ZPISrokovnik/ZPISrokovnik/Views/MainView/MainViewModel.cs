﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.MainView
{
	public class MainViewModel : BaseViewModel
	{
        #region Constructor
        public MainViewModel (IPageService page)
		{
            this.pageService = page;
            SearchCommand = new Command(Search);
            GetDataByUserInstance();
		}
        #endregion

        #region Properties
        private IPageService pageService;
        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetValue(ref searchText, value);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private string caption;
        public string Caption
        {
            get { return caption; }
            set
            {
                SetValue(ref caption, value);
                OnPropertyChanged(nameof(Caption));
            }
        }

        private long? brojIstraznihZatvorenikaMuski;
        public long? BrojIstraznihZatvorenikaMuski
        {
            get { return brojIstraznihZatvorenikaMuski; }
            set
            {
                SetValue(ref brojIstraznihZatvorenikaMuski, value);
                OnPropertyChanged(nameof(BrojIstraznihZatvorenikaMuski));
            }
        }

        private long? brojIstraznihZatvorenikaZenski;
        public long? BrojIstraznihZatvorenikaZenski
        {
            get { return brojIstraznihZatvorenikaZenski; }
            set
            {
                SetValue(ref brojIstraznihZatvorenikaZenski, value);
                OnPropertyChanged(nameof(BrojIstraznihZatvorenikaZenski));
            }
        }

        private long? brojKaznjenikaMuski;
        public long? BrojKaznjenikaMuski
        {
            get { return brojKaznjenikaMuski; }
            set
            {
                SetValue(ref brojKaznjenikaMuski, value);
                OnPropertyChanged(nameof(BrojKaznjenikaMuski));
            }
        }

        private long? brojKaznjenikaZenski;
        public long? BrojKaznjenikaZenski
        {
            get { return brojKaznjenikaZenski; }
            set
            {
                SetValue(ref brojKaznjenikaZenski, value);
                OnPropertyChanged(nameof(BrojKaznjenikaZenski));
            }
        }

        private long? brojZatvorenikaMuski;
        public long? BrojZatvorenikaMuski
        {
            get { return brojZatvorenikaMuski; }
            set
            {
                SetValue(ref brojZatvorenikaMuski, value);
                OnPropertyChanged(nameof(BrojZatvorenikaMuski));
            }
        }

        private long? brojZatvorenikaZenski;
        public long? BrojZatvorenikaZenski
        {
            get { return brojZatvorenikaZenski; }
            set
            {
                SetValue(ref brojZatvorenikaZenski, value);
                OnPropertyChanged(nameof(BrojZatvorenikaZenski));
            }
        }

        private long? naIzlaskuMuski;
        public long? NaIzlaskuMuski
        {
            get { return naIzlaskuMuski; }
            set
            {
                SetValue(ref naIzlaskuMuski, value);
                OnPropertyChanged(nameof(NaIzlaskuMuski));
            }
        }

        private long? naIzlaskuZenski;
        public long? NaIzlaskuZenski
        {
            get { return naIzlaskuZenski; }
            set
            {
                SetValue(ref naIzlaskuZenski, value);
                OnPropertyChanged(nameof(NaIzlaskuZenski));
            }
        }

        private long? naPrekidMuski;
        public long? NaPrekidMuski
        {
            get { return naPrekidMuski; }
            set
            {
                SetValue(ref naPrekidMuski, value);
                OnPropertyChanged(nameof(NaPrekidMuski));
            }
        }

        private long? naPrekidZenski;
        public long? NaPrekidZenski
        {
            get { return naPrekidZenski; }
            set
            {
                SetValue(ref naPrekidZenski, value);
                OnPropertyChanged(nameof(NaPrekidZenski));
            }
        }

        private long? prolazniMuski;
        public long? ProlazniMuski
        {
            get { return prolazniMuski; }
            set
            {
                SetValue(ref prolazniMuski, value);
                OnPropertyChanged(nameof(ProlazniMuski));
            }
        }

        private long? prolazniZenski;
        public long? ProlazniZenski
        {
            get { return prolazniZenski; }
            set
            {
                SetValue(ref prolazniZenski, value);
                OnPropertyChanged(nameof(ProlazniZenski));
            }
        }

        private long? uBijeguMuski;
        public long? UBijeguMuski
        {
            get { return uBijeguMuski; }
            set
            {
                SetValue(ref uBijeguMuski, value);
                OnPropertyChanged(nameof(UBijeguMuski));
            }
        }

        private long? uBijeguZenski;
        public long? UBijeguZenski
        {
            get { return uBijeguZenski; }
            set
            {
                SetValue(ref uBijeguZenski, value);
                OnPropertyChanged(nameof(UBijeguZenski));
            }
        }
        #endregion

        #region Commands
        public Command SearchCommand { get; private set; }
        #endregion

        #region Methods
        private void Search()
        {
            //if(Regex.IsMatch(SearchText, @"^\d+$"))
            MessagingCenter.Send<MainViewModel, string>(this, "oibImePrezime", SearchText);
            pageService.PushAsync(new MainSearch());
        }

        private void GetDataByUserInstance()
        {
            BrojcanoStanjeDTO brojcanoStanje = App.client.VratiBrojcanoStanje(App.TijeloId, "");
            DTOToObject(brojcanoStanje);
        }
        private void DTOToObject(BrojcanoStanjeDTO obj)
        {
            Caption = obj.NazivTijela;
            BrojIstraznihZatvorenikaMuski = obj.BrojIstraznihZatvorenikaMuski.HasValue ? obj.BrojIstraznihZatvorenikaMuski.Value : (long?) null;
            BrojIstraznihZatvorenikaZenski = obj.BrojIstraznihZatvorenikaZenski.HasValue ? obj.BrojIstraznihZatvorenikaZenski.Value : (long?)null;
            BrojKaznjenikaMuski = obj.BrojKaznjenikaMuski.HasValue ? obj.BrojKaznjenikaMuski.Value : (long?)null;
            BrojKaznjenikaZenski = obj.BrojKaznjenikaZenski.HasValue ? obj.BrojKaznjenikaZenski.Value : (long?)null;
            BrojZatvorenikaMuski = obj.BrojZatvorenikaMuski.HasValue ? obj.BrojZatvorenikaMuski.Value : (long?)null;
            BrojZatvorenikaZenski = obj.BrojZatvorenikaZenski.HasValue ? obj.BrojZatvorenikaZenski.Value : (long?)null;
            NaIzlaskuMuski = obj.NaIzlaskuMuski.HasValue ? obj.NaIzlaskuMuski.Value : (long?)null;
            NaIzlaskuZenski = obj.NaIzlaskuZenski.HasValue ? obj.NaIzlaskuZenski.Value : (long?)null;
            NaPrekidMuski = obj.NaPrekidMuski.HasValue ? obj.NaPrekidMuski.Value : (long?)null;
            NaPrekidZenski = obj.NaPrekidZenski.HasValue ? obj.NaPrekidZenski.Value : (long?)null;
            ProlazniMuski = obj.ProlazniMuski.HasValue ? obj.ProlazniMuski.Value : (long?)null;
            ProlazniZenski = obj.ProlazniZenski.HasValue ? obj.ProlazniZenski.Value : (long?)null;
            UBijeguMuski = obj.UBijeguMuski.HasValue ? obj.UBijeguMuski.Value : (long?)null;
            UBijeguZenski = obj.UBijeguZenski.HasValue ? obj.UBijeguZenski.Value : (long?)null;
        }
        #endregion
    }
}