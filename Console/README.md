# Probe-Landing-Scanning

Um conjunto de sondas foi enviado pela NASA � Marte e ir� pousar num planalto. Esse planalto, que curiosamente � retangular, deve ser explorado pelas sondas para que suas c�meras embutidas consigam ter uma vis�o completa da �rea e enviar as imagens de volta para a Terra.
A posi��o e dire��o de uma sonda s�o representadas por uma combina��o de coordenadas x-y e uma letra representando a dire��o cardinal para qual a sonda aponta, seguindo a rosa dos ventos em ingl�s.

O planalto � dividido numa malha para simplificar a navega��o. Um exemplo de posi��o seria (0, 0, N), que indica que a sonda est� no canto inferior esquerdo e apontando para o Norte.
Para controlar as sondas, a NASA envia uma simples sequ�ncia de letras. As letras poss�veis s�o "L", "R" e "M". Destas, "L" e "R" fazem a sonda virar 90 graus para a esquerda ou direita, respectivamente, sem mover a sonda. "M" faz com que a sonda mova-se para a frente um ponto da malha, mantendo a mesma dire��o.
Nesta malha o ponto ao norte de (x,y) � sempre (x, y+1).
Voc� deve fazer um programa que processe uma s�rie de instru��es enviadas para as sondas que est�o explorando este planalto. O formato da entrada e sa�da deste programa segue abaixo.
A forma de entrada e sa�da dos dados fica � sua escolha.

# Entrada
A primeira linha da entrada de dados � a coordenada do ponto superior-direito da malha do planalto. Lembrando que a inferior esquerda sempre ser� (0,0).
O resto da entrada ser� informa��o das sondas que foram implantadas. Cada sonda � representada por duas linhas. A primeira indica sua posi��o inicial e a segunda uma s�rie de instru��es indicando para a sonda como ela dever� explorar o planalto.
A posi��o � representada por dois inteiros e uma letra separados por espa�os, correspondendo � coordenada X-Y e � dire��o da sonda. Cada sonda ser� controlada sequencialmente, o que quer dizer que a segunda sonda s� ir� se movimentar ap�s que a primeira tenha terminado suas instru��es.


# Saida
A sa�da dever� contar uma linha para cada sonda, na mesma ordem de entrada, indicando sua coordenada final e dire��o.


## Como Rodar

Basta rodar o comando `dotnet run` dentro da pasta que se encontra o arquivo entrada.txt (Console/entrada.txt).

## Rodar testes

Basta rodar o comando `dotnet test .\Solution.sln` dentro da root.

<br>
