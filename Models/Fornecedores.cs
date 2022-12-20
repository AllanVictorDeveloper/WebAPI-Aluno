using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models
{

    [Table("tb_fornecedores")]
    public class Fornecedores
    {
        // Propriedades
        [Key]
        [Column("cod")]
        [JsonIgnore]
        public int Codigo { get; set; }
        
        [Column("nome_fantasia")]
        [Required]
        [JsonPropertyName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Column("razao_social")]
        [Required]
        [JsonPropertyName("Razao Social")]
        public string RazaoSocial { get; set; }

        [Column("cpf_cnpj")]
        [Required]
        [JsonIgnore]
        public string cpf_cnpj { get; set; }

        [NotMapped]
        public string CPF { get {return this.cpf_cnpj ;} set {this.cpf_cnpj = value ;} }
        
        [NotMapped]
        public string CNPJ { get {return this.cpf_cnpj ;} set {this.cpf_cnpj = value ;} }

        [Column("endereco")]
        [Required]
        public string Endereco { get; set; }
        
    }
}