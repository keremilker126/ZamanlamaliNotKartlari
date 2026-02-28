using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AkilliTakipSistemi.Models;

namespace AkilliTakipSistemi.Controllers;

public class NoteController : Controller
{
    public IActionResult Index()
    {

        return View(VeriTabani.notes);
    }


    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Note note)
    {
        note.Id = VeriTabani.notes.Count + 1;
        VeriTabani.notes.Add(note);
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
        Note note = VeriTabani.notes.FirstOrDefault(n => n.Id == id);
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
#pragma warning restore CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
        VeriTabani.notes.Remove(note);
        return RedirectToAction("Index");
    }




    [HttpGet]
    public IActionResult Duzenle(int id)
    {
        Note note = VeriTabani.notes.FirstOrDefault(n => n.Id == id);
        if (note != null)
        {
            return View(note);
        }
        return RedirectToAction("Index");
        

    }

    [HttpPost]
    public IActionResult Duzenle(Note note)
    {
        Note DuzenlennecekNot= VeriTabani.notes.FirstOrDefault(n => n.Id == note.Id);
        if(DuzenlennecekNot != null)
        {
            DuzenlennecekNot.Icerik= note.Icerik;
            DuzenlennecekNot.Başlik= note.Başlik;
            DuzenlennecekNot.NeZamanaKadar= note.NeZamanaKadar;
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }



}
