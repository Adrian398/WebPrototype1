namespace WebPrototype1.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HandyModels : DbContext
    {
        // Der Kontext wurde für die Verwendung einer HandyModels-Verbindungszeichenfolge aus der 
        // Konfigurationsdatei ('App.config' oder 'Web.config') der Anwendung konfiguriert. Diese Verbindungszeichenfolge hat standardmäßig die 
        // Datenbank 'WebPrototype1.Models.HandyModels' auf der LocalDb-Instanz als Ziel. 
        // 
        // Wenn Sie eine andere Datenbank und/oder einen anderen Anbieter als Ziel verwenden möchten, ändern Sie die HandyModels-Zeichenfolge 
        // in der Anwendungskonfigurationsdatei.
        public HandyModels()
            : base("name=HandyModels")
        {
        }

        // Fügen Sie ein 'DbSet' für jeden Entitätstyp hinzu, den Sie in das Modell einschließen möchten. Weitere Informationen 
        // zum Konfigurieren und Verwenden eines Code First-Modells finden Sie unter 'http://go.microsoft.com/fwlink/?LinkId=390109'.

         public virtual DbSet<Handy> Handies { get; set; }
    }

    public class Handy
    {
        public int HandyId { get; set; }
        public string Name { get; set; }
    }
}