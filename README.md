# LojaRpj
ProjetoFaculdade Vladimir LojaRpj
Trabalho de Conclusão do 1º Bimestre: Loja “A Doninha
Encantada“
Curso: Análise e Desenvolvimento de Sistemas
Disciplina: Desenvolvimento de Sistemas
Professor: Vladmir Cruz
1. O Cenário
Você e a sua equipe de desenvolvedores foram contratados pelo Sr. Getúlio Setter para modernizar a sua loja
de suprimentos: “A Doninha Encantada“. O dono da loja não aguenta mais anotar as vendas de espadas,
escudos e poções em pergaminhos de papel.
Sua missão é construir um sistema (Aplicação de Console interativa) que gerencie o estoque, processe as
vendas e gere relatórios financeiros usando as melhores práticas de Arquitetura de Software em C#.
2. Escopo do Sistema (Módulos Obrigatórios)
O sistema deve ter um menu principal interativo em loop que conecte o usuário aos seguintes módulos:
Módulo 1: Gestão de Estoque (Materiais e Preços)
Capacidade de cadastrar novos itens na loja.
Cada item deve ter: ID, Nome, Preço, Quantidade em Estoque e Tipo (Arma, Poção, etc.).
Capacidade de atualizar o preço de um item existente.
Capacidade de repor o estoque de um item existente.
Módulo 2: Controle de Vendas
O usuário deve poder "vender" um item informando o ID e a quantidade desejada.
O sistema deve calcular o valor total da venda.
Regra de Negócio: O sistema não pode permitir a venda se a quantidade solicitada for maior que o
estoque atual (Deve lançar exceção / erro amigável).
Toda venda bem-sucedida deve ser registrada no histórico de vendas do sistema.
Módulo 3: Relatórios (Painel do Gerente)
Relatório de Estoque: Listar todos os itens que ainda possuem estoque maior que zero, ordenados do
mais caro para o mais barato.
Relatório de Vendas: Listar o histórico de todas as vendas realizadas.
Fechamento de Caixa: Exibir o valor total (R$) arrecadado com todas as vendas.
3. Requisitos Técnicos Obrigatórios
Para obter a nota máxima, o código fonte DEVE conter as seguintes implementações que aprendemos em
sala:
Herança e Polimorfismo: Crie uma classe mãe abstrata ItemRPG e pelo menos duas classes filhas (Ex:
Arma e Pocao ou Consumivel e Equipamento). Use polimorfismo em algum cálculo ou exibição.
Encapsulamento e Defesa: Nenhuma classe deve permitir preço negativo ou estoque negativo. Use
try-catch e throw para proteger suas regras de negócio.
Arquitetura Limpa: A lista de itens e a lógica de vendas NÃO podem ficar soltas dentro do Program.cs.
Crie uma classe "Serviço" (Ex: LojaService) para ser o cérebro do aplicativo.
Consultas com LINQ: Os relatórios do Módulo 3 DEVEM ser construídos utilizando System.Linq
(.Where, .Sum, .OrderBy, etc.). O uso de loops manuais para gerar relatórios resultará em perda de
pontos.
4. Regras de Entrega e Composição do Grupo
Formação: Grupos de 3 a 4 alunos (Não será permitido trabalho individual ou duplas, sem exceções). Os
grupos deverão ser registrados no seguinte link: https://bit.ly/gruposadsp1
Entregáveis (Pacote Digital): O grupo deverá submeter um arquivo compacto contendo:
O arquivo .cs com todo o código-fonte do projeto.
No arquivo principal é obrigatório conter um cabeçalho no seguinte formato:
/*
Alunos
[
 Nome: Nome do Aluno 1
 RA: RA do Aluno 1
 E-mail: E-mail do aluno 1
],
[
 Nome: Nome do Aluno 2
 RA: RA do Aluno 2
 E-mail: E-mail do aluno 2
]
*/
using System;
// Segue o resto do código, uma nota IMPORTANTE, no comentário acima, com essa
estrutura, podem adicionar quantos alunos quiserem, desde que sejam no máximo 4 e
todos os membros do grupo!
A Apresentação em PDF (os slides que serão usados no dia).
O Documento de Detalhamento Técnico (Um PDF estilizado como o nosso material didático, explicando
como o grupo dividiu as classes, onde usaram LINQ, onde usaram herança e como o sistema foi
arquitetado).
5. Avaliação e Defesa (Pitch)
Todos os grupos farão uma apresentação (pitch) do software no dia da avaliação final para toda a turma e
professores.
Preparação para Apresentação: Tenham suas apresentações e código prontos para o dia, levem tudo
em um "Pen Drive" e também recomendo guardar uma cópia na nuvem, para que minimizemos o
tempo de preparação para apresentação.
Tempo de Apresentação: Máximo de 4 minutos por grupo. (Sejam diretos: mostrem o problema, a
arquitetura escolhida e rodem o programa).
Esclarecimentos: Após o pitch, os professores terão 4 minutos para fazer perguntas técnicas sobre o
código aos membros do grupo.
Presença: A nota da apresentação e arguição é individual. Membros do grupo que não estiverem
presentes no dia da defesa receberão redução na nota (podendo ser ZERO), independentemente de
terem ajudado a escrever o código.

6. Critérios de Avaliação (Rubrica)
Critério Peso Descrição
Funcionamento
(CRUD)
2.0 O sistema roda sem quebrar? Cadastra, vende e lista corretamente?
Arquitetura e POO 3.0
Uso correto de Herança, Interfaces, Encapsulamento e separação do
Main.
LINQ e Coleções 2.0 Uso eficiente do LINQ para gerar os relatórios solicitados.
Documentação 1.0 Qualidade do PDF de detalhamento técnico do sistema.
Apresentação (Pitch) 2.0 Clareza, domínio técnico durante as perguntas e gestão do tempo.
Boa sorte, aventureiros! Que o código compile de primeira.
