import socket #linha 1
import time #linha 2

def aguardandoConexao(host, port, velocidade):
    tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM) #linha 5
    orig = (host, port) #linha 6
    tcp.bind(orig) #linha 7

    tcp.listen(1) #linha 9

    print ("================== Servidor Ligado ================")
        
    while True:
        con, cliente = tcp.accept() #linha 14

        print ("Conectado por", cliente) #linha 16
        
        while True:

            msgCode = con.recv(1024) #linha 20

            msgDeco = msgCode.decode() #linha 22

            if msgDeco ==  'frente': #linha 24
                print ("Comando Frente Recebido!! \n")
    
            elif msgDeco == "esquerda": #linha 27
                print ("Comando Esquerda Recebido!! \n")
                        
            elif msgDeco == "direita": #linha 30
                print ("Comando Direita Recebido!! \n")
                        
            elif msgDeco == "atras": #linha 33
                print ("Comando atras Recebido!! \n")
                        
    print ("Finalizando conexao do cliente \n", cliente)

    con.close() #linha 38

aguardandoConexao('172.16.44.6',5000,30) #linha 40