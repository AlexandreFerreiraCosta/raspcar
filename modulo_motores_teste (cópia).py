import RPi.GPIO as GPIO #linha 1
import time #linha 2

#========| FUNÇÃO ANDAR FRENTE |==============
def frente(list, velocidade):
    print("FUNÇÃO FRENTE")

    GPIO.setmode(GPIO.BOARD) #linha 8
    GPIO.setup(36,GPIO.OUT) #linha 9
    GPIO.setup(35,GPIO.OUT) #linha 10
    
    pwm= GPIO.PWM(36,100) #linha 12
    pwm.start(0) #linha 13
    pwm.ChangeDutyCycle(velocidade) #linha 14
    
    pwm2 = GPIO.PWM(35,100) #linha 16
    pwm2.start(0) #linha 17
    pwm2.ChangeDutyCycle(velocidade) #linha 18

    for i in range (0, len(list)): 
        print("Setando porta %d como GPIO", list[i])
        GPIO.setup(list[i],GPIO.OUT) #linha 22

    GPIO.output(list[0], GPIO.LOW) #linha 24
    GPIO.output(list[1], GPIO.HIGH) #linha 25

    GPIO.output(list[2], GPIO.HIGH) #linha 27
    GPIO.output(list[3], GPIO.LOW) #linha 28

    time.sleep(2) #linha 30
    
#========| FUNÇÃO ANDAR ATRAS |==============
def atras(list, velocidade):
    print("FUNÇÃO TRAS")

    GPIO.setmode(GPIO.BOARD) #linha 36

    GPIO.setup(36,GPIO.OUT) #linha 38
    pwm = GPIO.PWM(36,100) #linha 39
    pwm.start(0) #linha 40
    pwm.ChangeDutyCycle(velocidade) #linha 41
        
    GPIO.setup(35,GPIO.OUT) #linha 43
    pwm2 = GPIO.PWM(35,100) #linha 44
    pwm2.start(0) #linha 45
    pwm2.ChangeDutyCycle(velocidade) #linha 46
    
    for i in range (0, len(list)):
        print("Setando porta %d como GPIO", list[i])
        GPIO.setup(list[i],GPIO.OUT) #linha 50

    GPIO.output(list[0], GPIO.HIGH) #linha 52
    GPIO.output(list[1], GPIO.LOW) #linha 53

    GPIO.output(list[2], GPIO.LOW) #linha 55
    GPIO.output(list[3], GPIO.HIGH) #linha 56

    time.sleep(2)

#=========| FUNÇÃO VIRAR ESQUERDA |==============
def direita(list, velocidade):
    print("FUNÇÃO VIRAR DIREITA")

    GPIO.setmode(GPIO.BOARD) #linha 64
        
    GPIO.setup(36,GPIO.OUT) #linha 66
    pwm = GPIO.PWM(36,100) #linha 67
    pwm.start(0) #linha 68
    pwm.ChangeDutyCycle(velocidade) #linha 69

    for i in range (0, len(list)):
        print("Setando porta %d como GPIO", list[i])
        GPIO.setup(list[i],GPIO.OUT) #linha 73
 
    time.sleep(2) #linha 75

#========| FUNÇÃO VIRAR DIREITA |==============
def esquerda(list, velocidade):
    print("FUNÇÃO VIRAR ESQUERDA")

    GPIO.setmode(GPIO.BOARD) #linha 81
        
    GPIO.setup(35,GPIO.OUT) #linha 83
    pwm2 = GPIO.PWM(35,100) #linha 84
    pwm2.start(0) #linha 85
    pwm2.ChangeDutyCycle(velocidade) #linha 86


    for i in range (0, len(list)):
        print("Setando porta %d como GPIO", list[i])
        GPIO.setup(list[i],GPIO.OUT) #linha 91
            
    time.sleep(2)
    
#========| FUNÇÃO LIMPAR |==============
def limpar():
    print("LIBERANDO PORTAS")
    GPIO.cleanup() #linha 98