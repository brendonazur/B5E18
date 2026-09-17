using IskolaiEszkoz.API.Model;

namespace IskolaiEszkoz.API.Service
{
    public interface IEszkozService
    {
        List<Eszkoz> OsszesLekerese();
        int Letrehozas(Eszkoz eszkoz);
        bool Modositas(int id, Eszkoz eszkoz);
        bool Torles(int id);
    }
}
