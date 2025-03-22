 using System.Data.SqlClient;
 
 namespace GeeckoCadastros.Models
 {
    public class CadUsuario
    {
        public string? Nome {get; set;}
        public int Senha {get; set;}
        public int Telefone {get; set;}
        public char Email {get; set;}
        public long CodBarras {get; set;}
        public string? CPF {get; set;}
        public int DataCadatro {get; set;}        
        public char Endereco {get; set;}
    }
 }
