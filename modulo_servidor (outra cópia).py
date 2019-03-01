#==================================================================CLASSE CONEXÃO=======================================================================#
# Classe Responsável por receber as informações do kinect.
# A comunicação é feita através de um socket.
# Utilizada para receber os gestos identificados pelo kinect.
#=======================================================================================================================================================#

import socket
import modulo_motores
import time

class Conexao:

    #Construtor da classe
    def __init__(self, host, port):
        self.Host = host
        self.Port = port

    #Delf: Aguarda a conexão com cliente.
    def aguardandoConexao(self, velocidade):
        host = self.Host
        port = self.Port

        #Métodos socket de conexão.
        tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        orig = (host, port)
        tcp.bind(orig)
        
        #Quantidade de conexão.
        tcp.listen(1)

        print ("===================================================")
        print ("================== Servidor Ligado ================")
        print ("==================================================\n")

        #Lista de portas GPIO.
        #Obs: Vai ser substituido.
        list = [11,12,15,16]
        
        while True:
            #Aguardando cliente conectar.
            con, cliente = tcp.accept()
            
            #Mostra o endereço do cliente.
            print ("Conectado por", cliente)
            mot = modulo_motores.Motores();
            
            while True:
                #Aguarda a mensagem do cliente.
                msgCode = con.recv(1024)

                #Decodificando a mensagem recebida.
                msgDeco = msgCode.decode()

                #Movimenta o robô para a frente.
                if msgDeco ==  'frente':
                        print ("Comando Frente Recebido!! \n")

                        #Chama o método frente da classe Motores.
                        #Parâmetro: List (motores GPIO).
                        #Parâmetro: Int (Velocidade dos motores).
                        mot.frente(list, 30)
                        mot.limpar()
                        
                #Movimenta o robô para a esquerda.
                elif msgDeco == "esquerda":
                        print ("Comando Esquerda Recebido!! \n")

                        #Chama o método esquerda da classe Motores.
                        #Parâmetro: List (motores GPIO).
                        #Parâmetro: Int (Velocida dos motores).
                        mot.esquerda(list, 40)
                        mot.limpar()
                        
                #Movimenta o robô para a direita.
                elif msgDeco == "direita":
                        print ("Comando Direita Recebido!! \n")

                        #Chama o método direita da classe Motores.
                        #Parâmetro: List (motores GPIO).
                        #Parâmetro: Int (Velocida dos motores).
                        mot.direita(list, 40)
                        mot.limpar()
                        
                #Movimenta o robô para a atras.
                elif msgDeco == "atras":
                        print ("Comando atras Recebido!! \n")
                        #Chama o método atras da classe Motores.
                        #Parâmetro: List (motores GPIO).
                        #Parâmetro: Int (Velocida dos motores).
                        mot.atras(list, 50)
                        mot.limpar()
                        
            print ("Finalizando conexao do cliente \n", cliente)

            #Fecha a conexão com cliente.
            con.close()

#conn = Conexao('172.16.44.29',5000)
#conn.aguardandoConexao()
