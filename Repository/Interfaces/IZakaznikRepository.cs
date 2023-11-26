using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IZakaznikRepository
    {
        List<Zakaznik> GetAllZakaznici();
        void DeleteZakaznik(int id);
        void UpdateAdresa(int id, Adresa adresa);
        void UpdateZakaznik(Zakaznik zakaznik, Adresa adresa);
        void UpdateUserData(Zakaznik zakaznik, Adresa adresa, UserData user, BinaryContent binaryContent, string newPass);
        void UpdateBinaryContent(BinaryContent binaryContent);
        List<Adresa> GetZakaznikAddress(int id);
        List<Zakaznik> GetZakaznikByUserId(int userId);
        void AddZakaznik(Zakaznik zakaznik, Adresa adresa);
        Task AddNewZakaznik(Zakaznik zakaznik, Adresa adresa, NetworkCredential cred);

    }
}
