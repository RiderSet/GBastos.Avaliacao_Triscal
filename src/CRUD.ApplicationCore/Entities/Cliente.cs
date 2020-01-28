using CRUD.ApplicationCore.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServiceStack.FluentValidation.Attributes;

namespace CRUD.ApplicationCore.Entities
{
    public class Cliente
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DataNascimento { get; set; }

        public IList<Endereco> Enderecos { get; set; } = new List<Endereco>();

        public bool IsValid { get; set; }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(Nome)
               && CPFCNPJValidation.IsValid(CpfCnpj)
               && string.IsNullOrEmpty(Convert.ToString(DataNascimento)))
            { IsValid = false; } else { IsValid = true; }
            return IsValid;
        }
    }
}