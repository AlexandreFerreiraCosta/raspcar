import RPi.GPIO as GPIO
GPIO.setmode(GPIO.BOARD)
import time

# limpa canais alocados
def limpar():
    GPIO.cleanup()

#aloca canais do dispositivo
def inicializar(list):
    for i in range (0, len(list)):
        GPIO.setup(list[i], GPIO.OUT)

# dispensa atvividade em canais
def parada(list):
    for i in range (0, len(list)):
        GPIO.output(list[i], GPIO.LOW)

#mtodo principal
def main():
    list = [11,12,15,16]
    inicializar(list)
    #implementacoes do run
    for i in range (0, 10): 
        GPIO.output(11, GPIO.HIGH)
        GPIO.output(12, GPIO.LOW)

        time.sleep(.2)
        parada(list)
        time.sleep(.1)

        GPIO.output(15, GPIO.LOW)
        GPIO.output(16, GPIO.HIGH)
        
        time.sleep(.2)
        parada(list)
        time.sleep(.1)
        
    parada(list)
    limpar()
    
#incializacao do programa
main()
