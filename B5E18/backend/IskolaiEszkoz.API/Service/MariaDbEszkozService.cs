using IskolaiEszkoz.API.Model;
using MySqlConnector;

namespace IskolaiEszkoz.API.Service
{
    public class MariaDbEszkozService : IEszkozService
    {
        private readonly string _connectionString;

        public MariaDbEszkozService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MariaDb");
        }

        public List<Eszkoz> OsszesLekerese()
        {
            List<Eszkoz> eszkozok = new List<Eszkoz>();

            using MySqlConnection kapcsolat = new MySqlConnection(_connectionString);
            kapcsolat.Open();

            string sql = @"
                SELECT id, nev, leltari_szam, kategoria, gyarto, modell,
                       terem, allapot, hasznalatban_van, kolcsonozheto,
                       beszerzesi_ar, beszerzes_datuma
                FROM eszkozok
                ORDER BY id;";

            using MySqlCommand parancs = new MySqlCommand(sql, kapcsolat);
            using MySqlDataReader olvaso = parancs.ExecuteReader();

            while (olvaso.Read())
            {
                Eszkoz eszkoz = new Eszkoz
                {
                    Id = Convert.ToInt32(olvaso["id"]),
                    Nev = olvaso["nev"].ToString(),
                    LeltariSzam = olvaso["leltari_szam"].ToString(),
                    Kategoria = olvaso["kategoria"].ToString(),
                    Gyarto = olvaso["gyarto"].ToString(),
                    Modell = olvaso["modell"].ToString(),
                    Terem = olvaso["terem"].ToString(),
                    Allapot = olvaso["allapot"].ToString(),
                    HasznalatbanVan = Convert.ToBoolean(olvaso["hasznalatban_van"]),
                    Kolcsonozheto = Convert.ToBoolean(olvaso["kolcsonozheto"]),
                    BeszerzesiAr = Convert.ToInt32(olvaso["beszerzesi_ar"]),
                    BeszerzesDatuma = Convert.ToDateTime(olvaso["beszerzes_datuma"])
                };

                eszkozok.Add(eszkoz);
            }

            return eszkozok;
        }

        public int Letrehozas(Eszkoz eszkoz)
        {
            using MySqlConnection kapcsolat = new MySqlConnection(_connectionString);
            kapcsolat.Open();

            string sql = @"
                INSERT INTO eszkozok
                (nev, leltari_szam, kategoria, gyarto, modell, terem, allapot,
                 hasznalatban_van, kolcsonozheto, beszerzesi_ar, beszerzes_datuma)
                VALUES
                (@nev, @leltariSzam, @kategoria, @gyarto, @modell, @terem, @allapot,
                 @hasznalatbanVan, @kolcsonozheto, @beszerzesiAr, @beszerzesDatuma);";

            using MySqlCommand parancs = new MySqlCommand(sql, kapcsolat);

            parancs.Parameters.AddWithValue("@nev", eszkoz.Nev);
            parancs.Parameters.AddWithValue("@leltariSzam", eszkoz.LeltariSzam);
            parancs.Parameters.AddWithValue("@kategoria", eszkoz.Kategoria);
            parancs.Parameters.AddWithValue("@gyarto", eszkoz.Gyarto);
            parancs.Parameters.AddWithValue("@modell", eszkoz.Modell);
            parancs.Parameters.AddWithValue("@terem", eszkoz.Terem);
            parancs.Parameters.AddWithValue("@allapot", eszkoz.Allapot);
            parancs.Parameters.AddWithValue("@hasznalatbanVan", eszkoz.HasznalatbanVan);
            parancs.Parameters.AddWithValue("@kolcsonozheto", eszkoz.Kolcsonozheto);
            parancs.Parameters.AddWithValue("@beszerzesiAr", eszkoz.BeszerzesiAr);
            parancs.Parameters.AddWithValue("@beszerzesDatuma", eszkoz.BeszerzesDatuma);

            parancs.ExecuteNonQuery();

            return Convert.ToInt32(parancs.LastInsertedId);
        }

        public bool Modositas(int id, Eszkoz eszkoz)
        {
            using MySqlConnection kapcsolat = new MySqlConnection(_connectionString);
            kapcsolat.Open();

            string sql = @"
                UPDATE eszkozok
                SET nev = @nev,
                    leltari_szam = @leltariSzam,
                    kategoria = @kategoria,
                    gyarto = @gyarto,
                    modell = @modell,
                    terem = @terem,
                    allapot = @allapot,
                    hasznalatban_van = @hasznalatbanVan,
                    kolcsonozheto = @kolcsonozheto,
                    beszerzesi_ar = @beszerzesiAr,
                    beszerzes_datuma = @beszerzesDatuma
                WHERE id = @id;";

            using MySqlCommand parancs = new MySqlCommand(sql, kapcsolat);

            parancs.Parameters.AddWithValue("@nev", eszkoz.Nev);
            parancs.Parameters.AddWithValue("@leltariSzam", eszkoz.LeltariSzam);
            parancs.Parameters.AddWithValue("@kategoria", eszkoz.Kategoria);
            parancs.Parameters.AddWithValue("@gyarto", eszkoz.Gyarto);
            parancs.Parameters.AddWithValue("@modell", eszkoz.Modell);
            parancs.Parameters.AddWithValue("@terem", eszkoz.Terem);
            parancs.Parameters.AddWithValue("@allapot", eszkoz.Allapot);
            parancs.Parameters.AddWithValue("@hasznalatbanVan", eszkoz.HasznalatbanVan);
            parancs.Parameters.AddWithValue("@kolcsonozheto", eszkoz.Kolcsonozheto);
            parancs.Parameters.AddWithValue("@beszerzesiAr", eszkoz.BeszerzesiAr);
            parancs.Parameters.AddWithValue("@beszerzesDatuma", eszkoz.BeszerzesDatuma);
            parancs.Parameters.AddWithValue("@id", id);

            int modositottSorok = parancs.ExecuteNonQuery();

            return modositottSorok > 0;
        }

        public bool Torles(int id)
        {
            using MySqlConnection kapcsolat = new MySqlConnection(_connectionString);
            kapcsolat.Open();

            string sql = "DELETE FROM eszkozok WHERE id = @id;";

            using MySqlCommand parancs = new MySqlCommand(sql, kapcsolat);
            parancs.Parameters.AddWithValue("@id", id);

            int toroltSorok = parancs.ExecuteNonQuery();

            return toroltSorok > 0;
        }
    }
}
