using ComercioOnline.Model;
using ComercioOnline.Model.Utilitarios;
using ComercioOnline.Teste.Utilitarios;
using dn32.infraestrutura;
using dn32.infraestrutura.Constantes;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using dn32.infraestrutura.Model;
using System;
using Xunit;

namespace ComercioOnline.Teste
{
    public class UnitTest1:TesteGenerico<Produto>
    {
        #region Infraestrutura
        public override void InicializarInfraestrutura()
        {
            UtilitariosdeTeste.InicializarInfraestrutura();
        }
        #endregion


        #region Cadastro
        [Fact(DisplayName =nameof(CadastroSemValor))]
        public void CadastroSemValor()
        {
            var produto = Produtinho();
            produto.Valor = 0m;
            var servico = FabricaDeServico.Crie<Produto>();
            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Cadastre(produto);
            });

            Assert.Equal(ConstantesDeValidacaoModel.VALOR_ERRADO_OTARIO, ex.Message);
            //servico.Remova(produto.Valor);
        }

       

        [Fact(DisplayName = nameof(CadastroSemNome))]
        public void CadastroSemNome()
        {

            var produto = Produtinho();
            produto.Nome = string.Empty;
            var servico = FabricaDeServico.Crie<Produto>();
            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Cadastre(produto);
            });

            Assert.Equal(ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO, ex.Message);
            //servico.Remova(produto.Nome);
        }
        #endregion



        
        
      #region MetódosPrivados
        private static Produto Produtinho()
        {
            return new Produto
            {
                Nome = "Compiuter com Impressão",
                Valor = 1515154.58m,
                CodigoDeBarra = "5154111451541"
            };
        }
        private Produto CadastroProduto()
        {
            var produto = Produtinho();
            var servico = FabricaDeServico.Crie<Produto>();
            servico.Cadastre(produto);
            return produto;
        }
        #endregion





        #region Consulta
        [Fact(DisplayName =nameof(ConsultaTeste))]
            public void ConsultaTeste()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = CadastroProduto();
            var produtoDoBanco = servico.Consulte(produto.Codigo);
            var igualdade = Compare(produto, produtoDoBanco,nameof(produto.DataDeAtualizacao),nameof(produto.DataDeCadastro));
            Assert.True(igualdade);
            servico.Remova(produto.Codigo);





        }





        #endregion




        #region Atualizacao
        [Fact(DisplayName = nameof(AtualizacaoSemValor))]
        public void AtualizacaoSemValor()
        {
            var produto = CadastroProduto();
            produto.Valor = 0m;
            var servico = FabricaDeServico.Crie<Produto>();
            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Atualize(produto);
            });

            Assert.Equal(ConstantesDeValidacaoModel.VALOR_ERRADO_OTARIO, ex.Message);
            servico.Remova(produto.Codigo);
        }



        [Fact(DisplayName = nameof(AtualizacaoSemNome))]
        public void AtualizacaoSemNome()
        {

            var produto = CadastroProduto();
            produto.Nome = string.Empty;
            var servico = FabricaDeServico.Crie<Produto>();
            var ex = Assert.Throws<Exception>(() =>
            {
                servico.Atualize(produto);
            });

            Assert.Equal(ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO, ex.Message);
            servico.Remova(produto.Codigo);
        }

            #endregion


        }
    }
