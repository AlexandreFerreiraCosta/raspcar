import RPi.GPIO as GPIO
GPIO.setmode(GPIO.BOARD)
import time

# limpa canais alocados
def limpar():
    GPIO.cleanup()

#criar canais do dispositivo
def inicializar(list):
    for i in range (0, len(list)):
        GPIO.setup(list[i], GPIO.OUT)

# dispensa atividade em canais
def parada(list):
    for i in range (0, len(list)):
        GPIO.output(list[i], GPIO.LOW)

# cria porta PWM
def Vel(port,velocidade):
    GPIO.setup(port,GPIO.OUT)
    pwm2 = GPIO.PWM(port,100)
    pwm2.start(0)
    pwm2.ChangeDutyCycle(velocidade)
        
#metodo principal
def main():
    list = [11,12,15,16]
    inicializar(list)
    
    GPIO.setup(36,GPIO.OUT)
    pwm = GPIO.PWM(36,100)
    pwm.start(0)
    pwm.ChangeDutyCycle(25)

    GPIO.setup(35,GPIO.OUT)
    pwm2 = GPIO.PWM(35,100)
    pwm2.start(0)
    pwm2.ChangeDutyCycle(25)
    
    #implementacoes do run
    condicao = 0
    while (condicao <= 10):
        GPIO.output(11, GPIO.LOW)
        GPIO.output(12, GPIO.HIGH)

        GPIO.output(16, GPIO.LOW)
        GPIO.output(15, GPIO.HIGH)

        condicao += 1
        
        time.sleep(.2)
        parada(list)
        time.sleep(.1)
        
    parada(list)
    limpar()
    
#incializacao do programa
main()
