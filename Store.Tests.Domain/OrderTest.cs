using Store.Domain.Entites;
using Store.Domain.Enum;
using System;
using Xunit;

namespace Store.Tests.Domain
{
    public class OrderTest
    {
        private readonly Customer _customer = new Customer("André", "andre@gmail.com");
        private readonly Product _product = new Product("Mesa", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [Fact]
        public void Deve_Adicionar_Um_Usuario_valido_com_nome_e_Email()
        {
            var order = new Order(_customer, 0, null);
            Assert.Equal(8, order.Number.Length);
        }
        [Fact]
        public void Dado_Um_Pedido_Deve_Ser_Aguardando_Pagamento()
        {
            var order = new Order(_customer, 0, null);
            Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
        }

        [Fact]
        public void Dado_Um_Pedido_Pago_Seu_Status_Deve_Ser_Alterado_Para_Pedido_Em_Entrega()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 1);
            order.Pay(10);
            Assert.Equal(EOrderStatus.WaitingDelivery, order.Status);
        }

        [Fact]
        public void Dado_Um_Novo_Item_Sem_Produto_Nao_Deve_Ser_Adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(null, 10);
            Assert.Equal(0, order.Items.Count);
        }

        [Fact]
        public void Dado_Um_Novo_Item_Com_Quantidade_Zero_O_Produto_Nao_Deve_Ser_Adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 0);
            Assert.Equal(0, order.Items.Count);
        }

        [Fact]
        public void Dado_Um_Pedido_Valido_Seu_Valor_Deve_Ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.Equal(50, order.Total());
        }

        [Fact]
        public void Dado_Expirado_o_pedido_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            var order = new Order(_customer, 10, expiredDiscount);
            order.AddItem(_product, 5);
            Assert.Equal(60, order.Total());
        }

        [Fact]
        public void Dado_Invalido_o_pedido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.Equal(60, order.Total());
        }

        [Fact]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.Equal(50, order.Total());
        }

        [Fact]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {

            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.Equal(60, order.Total());
        }

        [Fact]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {

            var order = new Order(null, 10, _discount);
            order.AddItem(_product, 5);
            Assert.False(order.IsValid);
        }
    }
}
   