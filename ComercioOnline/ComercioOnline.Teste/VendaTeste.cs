using ComercioOnline.Model;
using ComercioOnline.Teste.Utilitarios;
using dn32.infraestrutura;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ComercioOnline.Teste
{
    public class VendaTeste : TesteGenerico<Venda>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosdeTeste.InicializarInfraestrutura();
        }
        [Fact(DisplayName =nameof(VendaCadastroTeste))]
        public void VendaCadastroTeste()
        {
            var servico = FabricaDeServico.Crie<Venda>();
            var venda = ObtenhaUmaVenda();
            servico.Cadastre(venda);
            Assert.NotEqual(0, venda.Codigo);
            servico.Remova(venda.Codigo);
        }
        private Venda ObtenhaUmaVenda()
        {
            return new Venda
            {
                Status = eStatusDaVenda.NOVA,
                ValorTotal = 0m,
                DescontoTotal = 0m
            };
        }
    }
}
