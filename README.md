# FIAP-IoT
Trabalho final da disciplina de IoT

#Integrantes

331214  JONAS YASSUNARI SAITO
330286  FLAVIO DIAS PÊGAS DA SILVA
330381  IGOR CABRAL CEBAN
331283  JOÃO ROBERTO JOSÉ JUNIOR
330473  RENATO STAIANOV NOVELLI

#IoT Controle de Passageiros

Nosso projeto de IoT prevê uma análise do número de passageiros que estão utilizando o sistema de metro.

Dessa forma, podemos verificar quantos usuários entraram no sistema e quantos saíram, assim poderíamos definir a necessidade de mais ou menos trens, berm como fluxos de uma estação, como ativar ou desativar uma escada rolante, rampas, etc..

No nosso exemplo, estamos usando um device enviando mensagens a cada 5 segundos, o que equivale a pouco mais de 17 mil mensagens enviadas por dia.
Nesse cenário, o custo do hub IoT é de 25 dólares, na região Leste dos EUA, o que nos permitiria enviar até 400 mil mensagens por dia.

Entretanto, num cenário real, de cálculo de passageiros transportados diariamente nos metros, esse valor seria maior. De acordo com o metro, em 2017, foram transportados diariamente cerca de 3,7milhões de passageiros.

Prevemos o uso do IoT toda vez que um passageiro entra ou sai do sistema metroviário. 

Diferentemente do nosso exemplo, onde a cada 5 segundos	 mandamos mensagem para o hub com o número já consolidado, e uma variável de alerta caso o número de usuário que entrou supera em uma determinada porcentagem o número de usuário que saíram.

Ou seja, para que o projeto aconteça, sera necessário um investimento de pelo menos 2,5 mil dólares por mês (deverá suportar pelo menos 7,5 milhões de mensagens por dia).
Além disso faremos uso do Azure Functions para análise das mensagens e tomadas da decisões que acima já destacamos, tornando o projeto bem caro, ainda mais porque, dessa forma, toda as catracas do metro devem ser dispositivos de IoT para poder enviar as informações à Azure, para seu processamento.

Sobre o Azure Functions, outra tecnologia que utilizaríamos, o custo é um pouco mais baixo, prevemos gastar até 1400 dólares por mês (com esse valor, já seria possível realizar até 222 milhões de execuções por mês).

Somente utilizando o IoT Hub e o Azure functions já chegamos a quase 4 mil dólares por mês.

No nosso exemplo, utilizamos também serviço de armazenamento que com certeza no cenário real deve ser utilizado, para verificar histórico e até mesmo por conta de auditorias. Também poderíamos incluir um serviço de power BI para verificar em tempo real como está a lotação do metro.
