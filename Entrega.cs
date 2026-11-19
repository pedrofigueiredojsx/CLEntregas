public class Entrega
{
    public int Id { get; set; }
    public string Destinatario { get; set; }
    public string Cidade { get; set; }
    public string Status { get; set; }

    public Entrega(int id, string destinatario, string cidade, string status)
    {
        Id = id;
        Destinatario = destinatario;
        Cidade = cidade;
        Status = status;
    }
}