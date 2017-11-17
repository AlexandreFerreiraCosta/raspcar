using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Net;

namespace camera
{
    public partial class MainWindow : Window
    {
        //KinectSensor kinect;
        bool MaoDireitaAcimaCabeca;
        bool MaoEsquerdaAcimaCabeca;
        //Socket client;

        public MainWindow()
        {
            /*client = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);*/

            /*IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.43.5"),5000);
            client.Connect(endPoint);*/

            InitializeComponent();

            //InicializarKinect();
        }

        /*private void InicializarKinect()
        {
             /*VERIFICANDO SE KINECT ESTÁ CONECTADO AO COMPUTADOR*/
        //kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);

        /*INICIANDO O SENSOR KINECT*/
        //kinect.Start();


        /*kinect.DepthStream.Enable();
        kinect.SkeletonStream.Enable();
        kinect.ColorStream.Enable();

        kinect.AllFramesReady += kinect_AllFramesReady;

        kinect.SkeletonFrameReady += KinectEvent;
        kinect.SkeletonStream.Enable();
   }


   private void kinect_AllFramesReady(object sender, AllFramesReadyEventArgs e)
   {
        byte[] imagem = ObterImagemSensorRGB(e.OpenColorImageFrame());
            if (imagem != null)
                canvasKinect.Background = new ImageBrush(BitmapSource.Create(kinect.ColorStream.FrameWidth,kinect.ColorStream.FrameHeight,
                        96, 96, PixelFormats.Bgr32, null,imagem,kinect.ColorStream.FrameBytesPerPixel* kinect.ColorStream.FrameWidth)
                );

            canvasKinect.Children.Clear();

            DesenharEsqueletoUsuario(e.OpenSkeletonFrame());
   }

   private void DesenharEsqueletoUsuario(SkeletonFrame quadro)
   { 
        if (quadro == null) return;

        using (quadro)
        {
            Skeleton[] esqueletos = new Skeleton[quadro.SkeletonArrayLength];
            quadro.CopySkeletonDataTo(esqueletos);
            IEnumerable<Skeleton> esqueletosRastreados = esqueletos.Where( esqueleto =>esqueleto.TrackingState ==SkeletonTrackingState.Tracked);
            if (esqueletosRastreados.Count() > 0)
            {
                Skeleton esqueleto = esqueletosRastreados.First();
                EsqueletoUsuarioAuxiliar funcoesEsqueletos = new EsqueletoUsuarioAuxiliar(kinect);
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.HandRight],canvasKinect);
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.HandLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.ShoulderCenter],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.WristRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.WristLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.ElbowRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.ElbowLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.Head],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.ShoulderRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.ShoulderLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.Spine],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.HipCenter],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.HipRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.HipLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.KneeRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.KneeLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.AnkleRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.AnkleLeft],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.FootRight],canvasKinect );
                funcoesEsqueletos.DesenharArticulacao(esqueleto.Joints[JointType.FootLeft],canvasKinect );
            }
        }   
   }

   private byte[] ObterImagemSensorRGB(ColorImageFrame quadro)
   {
        if (quadro == null) return null;

        using (quadro)
        {
            byte[] bytesImagem = new byte[quadro.PixelDataLength];
            quadro.CopyPixelDataTo(bytesImagem);

            return bytesImagem;
        }
   }

   //MAO DIREITA
   private void ExecutarRegraMaoDireitaAcimaDaCabeca(SkeletonFrame quadroAtual)
   {
        Skeleton[] esqueletos = new Skeleton[6];
        quadroAtual.CopySkeletonDataTo(esqueletos);
        Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

        if (usuario != null)
        {
            Joint maoDireita = usuario.Joints[JointType.HandRight];
            Joint cabeca = usuario.Joints[JointType.Spine];
            bool novoTesteMaoDireitaAcimaCabeca = maoDireita.Position.Y > cabeca.Position.Y;

            /*if((MaoDireitaAcimaCabeca != novoTesteMaoDireitaAcimaCabeca)&&(MaoEsquerdaAcimaCabeca != novoTesteMaoEsquerdaAcimaCabeca))
            {
                MaoEsquerdaAcimaCabeca = novoTesteMaoEsquerdaAcimaCabeca;
                MaoDireitaAcimaCabeca = novoTesteMaoDireitaAcimaCabeca;
                if ((MaoEsquerdaAcimaCabeca)&&(MaoDireitaAcimaCabeca))
                    MessageBox.Show("Mão esquerda e direita Levantada");
                    cont = 1;
                    byte[] buffer = Encoding.Default.GetBytes("frente");
                    client.Send(buffer,0,buffer.Length,0);
            }*/

        /*if ((MaoDireitaAcimaCabeca != novoTesteMaoDireitaAcimaCabeca))
        {
                MaoDireitaAcimaCabeca = novoTesteMaoDireitaAcimaCabeca;
                if (MaoDireitaAcimaCabeca){
                    //MessageBox.Show("Mão direita Levantada");
                    byte[] buffer = Encoding.Default.GetBytes("direita");
                    client.Send(buffer,0,buffer.Length,0);
                }
        }/*else{
             byte[] buffer = Encoding.Default.GetBytes("frente");
             client.Send(buffer,0,buffer.Length,0);
        }

    }
}*/

        //REGRA MAO ESQUERDA
        /*private void ExecutarRegraMaoEsquerdaAcimaDaCabeca(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6];
            quadroAtual.CopySkeletonDataTo(esqueletos);

            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null)
            {
                Joint cabeca = usuario.Joints[JointType.Spine];
                Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                bool novoTesteMaoEsquerdaAcimaCabeca = maoEsquerda.Position.Y > cabeca.Position.Y;

                if((MaoEsquerdaAcimaCabeca != novoTesteMaoEsquerdaAcimaCabeca)){
                    MaoEsquerdaAcimaCabeca = novoTesteMaoEsquerdaAcimaCabeca;
                    if (MaoEsquerdaAcimaCabeca){
                        //MessageBox.Show("Mão esquerda Levantada");
                        byte[] buffer = Encoding.Default.GetBytes("esquerda");
                        client.Send(buffer,0,buffer.Length,0);
                    }
                }/*else{
                        byte[] buffer = Encoding.Default.GetBytes("frente");
                        client.Send(buffer,0,buffer.Length,0);
                }       
            }
        }*/

        //MAO DIREITA E ESQUERDA LEVANTADA
        /*private void ExecutarRegraMaoDireitaeEsquerdaAcimaDaCabeca(SkeletonFrame quadroAtual)
        {
             Skeleton[] esqueletos = new Skeleton[6];
             quadroAtual.CopySkeletonDataTo(esqueletos);
             Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

             if (usuario != null)
             {
                 Joint maoDireita = usuario.Joints[JointType.HandRight];
                 Joint cabeca = usuario.Joints[JointType.Spine];
                 bool novoTesteMaoDireitaAcimaCabeca = maoDireita.Position.Y > cabeca.Position.Y;

                 //Joint cabeca = usuario.Joints[JointType.Spine];
                 Joint maoEsquerda = usuario.Joints[JointType.HandLeft];
                 bool novoTesteMaoEsquerdaAcimaCabeca = maoEsquerda.Position.Y > cabeca.Position.Y;

                 if((MaoDireitaAcimaCabeca != novoTesteMaoDireitaAcimaCabeca)&&(MaoEsquerdaAcimaCabeca != novoTesteMaoEsquerdaAcimaCabeca))
                 {
                     MaoEsquerdaAcimaCabeca = novoTesteMaoEsquerdaAcimaCabeca;
                     MaoDireitaAcimaCabeca = novoTesteMaoDireitaAcimaCabeca;
                     if ((MaoEsquerdaAcimaCabeca)&&(MaoDireitaAcimaCabeca)){
                         //MessageBox.Show("Mão esquerda e direita Levantada");
                         byte[] buffer = Encoding.Default.GetBytes("frente");
                         client.Send(buffer,0,buffer.Length,0);
                     }
                 }/*else{
                         byte[] buffer = Encoding.Default.GetBytes("frente");
                         client.Send(buffer,0,buffer.Length,0);
                 }

                 /*if ((MaoDireitaAcimaCabeca != novoTesteMaoDireitaAcimaCabeca))
                 {
                         MaoDireitaAcimaCabeca = novoTesteMaoDireitaAcimaCabeca;
                         if (MaoDireitaAcimaCabeca)
                             MessageBox.Show("Mão direita Levantada");
                             //byte[] buffer = Encoding.Default.GetBytes("direita");
                             //client.Send(buffer,0,buffer.Length,0);
                 }         
             }
         }*/

        /*private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {
                if (quadroAtual != null)
                {
                    ExecutarRegraMaoDireitaeEsquerdaAcimaDaCabeca(quadroAtual);
                    ExecutarRegraMaoDireitaAcimaDaCabeca(quadroAtual);
                    ExecutarRegraMaoEsquerdaAcimaDaCabeca(quadroAtual);
                }
            }
        }
    }
//============================================================================================================================================================
//=============================================================CLASSE ESQUELETO USUARIO AUXILIAR==============================================================
//============================================================================================================================================================
    public class EsqueletoUsuarioAuxiliar
    {
        private KinectSensor kinect;
        public EsqueletoUsuarioAuxiliar(KinectSensor kinect)
        {
            this.kinect = kinect;
        }

        private ColorImagePoint ConverterCoordenadasArticulacao(Joint articulacao, double larguraCanvas, double alturaCanvas)
        {
            ColorImagePoint posicaoArticulacao = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(articulacao.Position, kinect.ColorStream.Format);
            posicaoArticulacao.X = (int)(posicaoArticulacao.X * larguraCanvas) / kinect.ColorStream.FrameWidth;
            posicaoArticulacao.Y = (int)(posicaoArticulacao.Y * alturaCanvas) / kinect.ColorStream.FrameHeight;

            return posicaoArticulacao;
        }

        private Ellipse CriarComponenteVisualArticulacao(int diametroArticulacao, int larguraDesenho, Brush corDesenho)
        {
            Ellipse objetoArticulacao = new Ellipse();
            objetoArticulacao.Height = diametroArticulacao;
            objetoArticulacao.Width = diametroArticulacao;
            objetoArticulacao.StrokeThickness = larguraDesenho;
            objetoArticulacao.Stroke = corDesenho;

            return objetoArticulacao;
        }

        public void DesenharArticulacao(Joint articulacao, Canvas canvasParaDesenhar)
        {
            int diametroArticulacao = articulacao.JointType == JointType.Head ? 50 : 10;
            int larguraDesenho = 4;
            Brush corDesenho = Brushes.LawnGreen;
            Ellipse objetoArticulacao = CriarComponenteVisualArticulacao(diametroArticulacao, larguraDesenho, corDesenho);

            ColorImagePoint posicaoArticulacao = ConverterCoordenadasArticulacao(articulacao, canvasParaDesenhar.ActualWidth, canvasParaDesenhar.ActualHeight);
            double deslocamentoHorizontal = posicaoArticulacao.X - objetoArticulacao.Width / 2;
            double deslocamentoVertical = (posicaoArticulacao.Y - objetoArticulacao.Height / 2);
            if (deslocamentoVertical >= 0 &&
                deslocamentoVertical < canvasParaDesenhar.ActualHeight && deslocamentoHorizontal >= 0 && deslocamentoHorizontal < canvasParaDesenhar.ActualWidth)
            {
                Canvas.SetLeft(objetoArticulacao, deslocamentoHorizontal);
                Canvas.SetTop(objetoArticulacao, deslocamentoVertical);
                Canvas.SetZIndex(objetoArticulacao, 100);

                canvasParaDesenhar.Children.Add(objetoArticulacao);
            }
        }
    }*/
    }
}