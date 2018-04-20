namespace WebPrototype1.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OfferingModels : DbContext
    {
        // Der Kontext wurde für die Verwendung einer OfferingModels-Verbindungszeichenfolge aus der 
        // Konfigurationsdatei ('App.config' oder 'Web.config') der Anwendung konfiguriert. Diese Verbindungszeichenfolge hat standardmäßig die 
        // Datenbank 'WebPrototype1.Models.OfferingModels' auf der LocalDb-Instanz als Ziel. 
        // 
        // Wenn Sie eine andere Datenbank und/oder einen anderen Anbieter als Ziel verwenden möchten, ändern Sie die OfferingModels-Zeichenfolge 
        // in der Anwendungskonfigurationsdatei.
        public OfferingModels()
            : base("name=OfferingModels")
        {
        }

        // Fügen Sie ein 'DbSet' für jeden Entitätstyp hinzu, den Sie in das Modell einschließen möchten. Weitere Informationen 
        // zum Konfigurieren und Verwenden eines Code First-Modells finden Sie unter 'http://go.microsoft.com/fwlink/?LinkId=390109'.

        public virtual DbSet<Offering> Offerings { get; set; }
    }

    public class Offering
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}