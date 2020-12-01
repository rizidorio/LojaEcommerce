# LojaEcommerce
Projeto DDD com Asp.Net Core 3.1 - MongoDb

Api para inclusão, edição, listagem e exclusão de produtos para um E-commerce.

Ao realizar o primeiro cadastro o banco de dados será criado localmente.

Para cadastrar um produto é necessário realizar o cadastro de uma categoria primeiro em api/categorias, passando um nome no corpo da requisição em formato JSON.

{

   "name": "nome da categoria"
   
}

Para cadastrar um produto acesse api/produtos, passando os dados informados abaixo no corpo da requisição em formato JSON.

{

	"SKU": "código de identificação", (string)
	"Name": "nome do produto", (string)
	"Description": "descrição do produto", (string)
	"Brand": "marca do produto", (string)
	"Category": "categoria do produto", (nome de uma categoria já cadastrada no banco
	"ImageUrl": "url da imagem", (string)
	"Price": preço do produto (decimal)
	
}

Você poderá listar todos os produtos, sem filtro, ou utilizar filtros conforme abaixo:

api/produtos/listarpornome/"nome do produto" - lista todos os produtos com o nome pesquisado;

api/produtos/listarporcategoria/"nome da categoria" - lista todos os produtos cadastrados ne categoria;

api/produtos/buscarporsku/"sku do produtos" - exibe os dados de um produto;

api/produtos/buscarprodutobyid/"id do produto" - exibe os dados de um produto;
