#=============================== CLASSE MOTORES =================================#
# Classe Responsável por movimentar os motores do robô.
# Utilizada para setar a velocidade dos motores.
# Responsável pela configuração das portas no Raspberry.

import RPi.GPIO as GPIO

import time

class Motores:

    def __init__(self):
        print("Objeto Criado \n")
        print("=================================================\n")

    
    def limpar(self):
        print("Limpado cache \n")
        GPIO.cleanup()


    def frente(self, list, velocidade):
        print("FUNÇÃO FRENTE")

        GPIO.setmode(GPIO.BOARD)
        
        GPIO.setup(36,GPIO.OUT)   #port 36
        pwm = GPIO.PWM(36,100)
        pwm.start(0)    #VELOCIDADE MOTOR ESQUERDO.
        pwm.ChangeDutyCycle(velocidade)
        
        
        GPIO.setup(35,GPIO.OUT)  #port 35
        pwm2 = GPIO.PWM(35,100)
        pwm2.start(0)   #VELOCIDADE MOTOR DIREITO
        pwm2.ChangeDutyCycle(velocidade)


        for i in range (0, len(list)):
            print("Setando porta %d como GPIO", list[i])
            GPIO.setup(list[i],GPIO.OUT)

        
        GPIO.output(list[0], GPIO.LOW)
        GPIO.output(list[1], GPIO.HIGH)


        GPIO.output(list[3], GPIO.LOW)
        GPIO.output(list[2], GPIO.HIGH)

        time.sleep(2)   #tempo de passagem de energia



    def atras(self, list, velocidade):
        print("FUNÇÃO TRAS")

        GPIO.setmode(GPIO.BOARD)
        
        GPIO.setup(36,GPIO.OUT)   #port 36
        pwm = GPIO.PWM(36,100)
        pwm.start(0)    #VELOCIDADE MOTOR ESQUERDO.
        pwm.ChangeDutyCycle(velocidade)
        
        
        GPIO.setup(35,GPIO.OUT)  #port 35
        pwm2 = GPIO.PWM(35,100)
        pwm2.start(0)   #VELOCIDADE MOTOR DIREITO
        pwm2.ChangeDutyCycle(velocidade)


        for i in range (0, len(list)):
            print("Setando porta %d como GPIO", list[i])
            GPIO.setup(list[i],GPIO.OUT)

        
        GPIO.output(list[1], GPIO.LOW)
        GPIO.output(list[0], GPIO.HIGH)


        GPIO.output(list[2], GPIO.LOW)
        GPIO.output(list[3], GPIO.HIGH)

        time.sleep(2)   #tempo que passagem de energia


    def esquerda(self, list, velocidade):
        print("FUNÇÃO DIREITA")

        GPIO.setmode(GPIO.BOARD)
        
        GPIO.setup(36,GPIO.OUT)   #port 36
        pwm = GPIO.PWM(36,100)
        pwm.start(0)    #VELOCIDADE MOTOR ESQUERDO.
        pwm.ChangeDutyCycle(velocidade)
        
        
        #GPIO.setup(35,GPIO.OUT)  #port 35
        #pwm2 = GPIO.PWM(35,100)
        #pwm2.start(0)   #VELOCIDADE MOTOR DIREITO
        #pwm2.ChangeDutyCycle(velocidade)


        for i in range (0, len(list)):
            print("Setando porta %d como GPIO", list[i])
            GPIO.setup(list[i],GPIO.OUT)

        
        #GPIO.output(list[0], GPIO.LOW)
        #GPIO.output(list[1], GPIO.HIGH)

        #motor esquerdo
        #GPIO.output(list[3], GPIO.LOW)
        #GPIO.output(list[2], GPIO.HIGH)

        #tempo que passagem de energia 
        time.sleep(2)   


    def direita(self, list, velocidade):
        print("FUNÇÃO ESQUERDA")

        GPIO.setmode(GPIO.BOARD)
        
        #GPIO.setup(36,GPIO.OUT)   #port 36
        #pwm = GPIO.PWM(36,100)
        #pwm.start(0)    #VELOCIDADE MOTOR ESQUERDO.
        #pwm.ChangeDutyCycle(velocidade)
        
        
        GPIO.setup(35,GPIO.OUT)  #port 35
        pwm2 = GPIO.PWM(35,100)
        pwm2.start(0)   #VELOCIDADE MOTOR DIREITO
        pwm2.ChangeDutyCycle(velocidade)


        for i in range (0, len(list)):
            print("Setando porta %d como GPIO", list[i])
            GPIO.setup(list[i],GPIO.OUT)

        #motor direita
        #GPIO.output(list[0], GPIO.LOW)
        GPIO.output(list[1], GPIO.HIGH)

        #motor esquerdo
        #GPIO.output(list[3], GPIO.LOW)
        #GPIO.output(list[2], GPIO.HIGH)

        #tempo que passagem de energia
        time.sleep(2) 


#list = [11,12,15,16]    #11,12,15,16
#motor = Motores()
#motor.frente(list,50)
#motor.limpar()
#motor.esquerda(list,50)
#motor.limpar()
#motor.direita(list,50)
#motor.limpar()
#motor.atras(list,50)
#motor.limpar()
