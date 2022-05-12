﻿using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Pedidos;
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string ChaveAcesso { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoViewModel EnderecoModel { get; set; }
        public List<PedidoModel> ListaPedidos { get; set; }
    }
}
