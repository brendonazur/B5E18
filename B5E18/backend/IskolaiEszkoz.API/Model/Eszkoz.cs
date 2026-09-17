namespace IskolaiEszkoz.API.Model
{
    public class Eszkoz
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string LeltariSzam { get; set; }
        public string Kategoria { get; set; }
        public string Gyarto { get; set; }
        public string Modell { get; set; }
        public string Terem { get; set; }
        public string Allapot { get; set; }
        public bool HasznalatbanVan { get; set; }
        public bool Kolcsonozheto { get; set; }
        public int BeszerzesiAr { get; set; }
        public DateTime BeszerzesDatuma { get; set; }
    }
}
