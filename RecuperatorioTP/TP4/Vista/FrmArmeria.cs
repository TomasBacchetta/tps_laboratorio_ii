using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;

namespace Vista
{
    public partial class FrmArmeria : Form
    {
        Soldado nuevoSoldado;
        private List<Arma> listaArmas;
        private int indice;

        
        public FrmArmeria(Soldado nuevoSoldado)
        {
            InitializeComponent();
            
            this.listaArmas = new List<Arma>();
            this.indice = 0;
            this.nuevoSoldado = nuevoSoldado;
            CargarArmas();
            ImprimirDatosArma();
            ActualizarEstadoBotonesNavegacion();

        }

        private void ImprimirDatosArma()
        {
            lblNombreArma.Text = listaArmas[indice].Modelo;
            rtbDatosArma.Text = listaArmas[indice].ToString();
            ptbArma.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"{listaArmas[indice].CodigoRetrato}");
        }
        /// <summary>
        /// habilita o desehabilita los botones de navegacion teniendo los limites del "cursor" como criterio
        /// </summary>
        private void ActualizarEstadoBotonesNavegacion()
        {
            

            if (indice > 0 && indice < listaArmas.Count - 1)
            {
                btnAnterior.Enabled = true;
                btnSiguiente.Enabled = true;
            } else
            {
                if (indice == 0)
                {
                    btnAnterior.Enabled = false;
                    btnSiguiente.Enabled = true;
                } else
                {
                    btnSiguiente.Enabled = false;
                    btnAnterior.Enabled = true;
                }
            }

            
        }
        

        private void CargarArmas()
        {
            switch (nuevoSoldado.ClaseDelSoldado)
            {
                case Soldado.ClaseSoldado.Asalto:
                    listaArmas.Add(new Arma("AK-74", "Fábrica de Armas de Tula", Arma.Tipo.Carabina, "El fusil de asalto AK-74N es una versión modernizada de la AKM, que fue desarrollado en 1974 y es de calibre 5,45 mm, menor que el de su predecesor. " +
                    "Su producción en serie empezó ese mismo año AK-74 quiere decir Rifle Automático Kalashnikov Modelo 1974. Compacta, durable y de alto calibre, es por antonomasia el arma de asalto de la Zona.", "c1"));

                    listaArmas.Add(new Arma("AR-15", "ArmaLite", Arma.Tipo.Carabina, "El ArmaLite AR-15 es un fusil de asalto de 5,56 mm, accionado por gas y alimentado desde cargadores de 25 y 20 cartuchos, " +
                    "que cuenta con un cerrojo rotativo y un diseño lineal. Fue diseñado por Eugene Stoner, Leroy James Sullivan y Bob Fremont, a partir del fusil AR-10. El AR-15 fue diseñado desde el inicio como un fusil de asalto ligero, " +
                    "que dispararía un nuevo cartucho con una bala de pequeño calibre y alta velocidad, que permitiría a los soldados transportar mayor cantidad de munición. Es la base de todos los fusiles AR, " +
                    "las carabinas más populares de los países miembros de la OTAN​, y no es raro toparse con una en la zona", "c2"));

                    listaArmas.Add(new Arma("AK-74U", "Izhmash", Arma.Tipo.Carabina, "El AKS-74U (АКС-74У) es un fusil de asalto compacto desarrollado en la Unión Soviética " +
                    "en la década de 1970. Es básicamente una versión corta del AK-74, que combina el tamaño reducido de un subfusil y el cartucho 5,45 x 39 del fusil. La 'U' de su nombre significa 'acortado' (Укороченный, Ukorochennyj).1​ " +
                    "En 1973, comenzó una competición impulsada por los ejércitos del pacto de Varsovia. Por su disminuido tamaño, es la preferida por grupos terroristas y por los habitantes de la Zona", "c3"));
                    break;
                case Soldado.ClaseSoldado.Medico:
                    listaArmas.Add(new Arma("MP5", "Heckler & Koch", Arma.Tipo.SubFusil, "El MP5 (abreviatura de Maschinenpistole 5) es un subfusil de calibre 9 mm de diseño alemán, desarrollado en los años 1960 por un equipo de ingenieros del fabricante de armas Heckler & Koch (H&K) de Oberndorf am Neckar, " +
                    "en Alemania Occidental. Hay más de 100 variantes del MP5, incluídas algunas versiones semiautomáticas.El MP5 es uno de los subfusiles más utilizados en el mundo, ya que ha sido adoptada por 40 naciones y numerosas organizaciones militares, policiales, de inteligencia y de seguridad. " +
                    "Fue ampliamente utilizado por los equipos SWAT en América del Norte, pero ha sido reemplazado en gran parte por las variantes AR - 15 en el siglo XXI, sin embargo encontró un hogar ideal en la Zona", "s1"));

                    listaArmas.Add(new Arma("PP-19 'Bizon'", "	Izhmash", Arma.Tipo.SubFusil, "El PP-19 Bizon es un subfusil calibre 9,19 mm, desarrollado a principios de 1990 en " +
                    "Izhmash por un equipo de ingenieros liderado por Victor Kalashnikov (hijo de Mikhail Kalashnikov, quien diseñó el AK-471​2​) y por Alexi Dragunov, el hijo menor de Evgeny Dragunov (diseñador del Fusil de francotirador Dragunov). " +
                    "El Bizon fue desarrollado a petición del Ministerio del Interior Ruso.3​ Está pensado principalmente para la lucha contra el terrorismo(contraterrorismo) y unidades policiales que necesitan disparar con precisión y rapidez a corta distancia.", "s2"));
                    break;
                case Soldado.ClaseSoldado.Reconocimiento:
                    listaArmas.Add(new Arma("SA80", "Royal Small Arms Factory", Arma.Tipo.Rifle, "El SA80 (en inglés significa Small Arms for the 1980s) es un fusil de asalto tipo bullpup de calibre 5,56 mm; diseñado y producido hasta 1988 por " +
                    "Royal Small Arms Factory en Enfield Lock, Reino Unido. " +
                    "En 1988 la producción del arma fue transferida a la factoría de armas Royal Ordnance de Nottingham (BAE Systems Land Systems Munitions & Ordnance), y en el 2000, Heckler & Koch de Alemania fue subcontratada para mejorar el arma ya existente y " +
                    "hacerla más fiable para operaciones en las que estuviese expuesta a factores medioambientales más extremos, como el desierto de Irak. Cualquier habitante de la Zona que quiera matar a distancia valorará este rifle", "r1"));

                    listaArmas.Add(new Arma("VKS", "CKIB SOO", Arma.Tipo.Rifle, "VKS (ВКС) o VSSK (ВССК) es ruso bullpup, acción de cerrojo de tiro recto, alimentado por cargador rifle de francotirador cámara para el 12,7 × 55 mm STs-130 ronda subsónica. " +
                    "El arma también se conoce con el nombre VSSK y el nombre adicional Vykhlop (Выхлоп), que proviene del programa de desarrollo. " +
                    "Fue desarrollado alrededor de 2002 para las unidades de fuerzas especiales de FSB.El rifle de francotirador silenciado VKS de 12, 7 × 55 mm está diseñado para operaciones especiales que requieren disparos silenciosos y una penetración muy superior a la proporcionada por 9 × 39 mm VSS rifle de francotirador silenciado.Los objetivos típicos del VKS son los combatientes con armadura pesada o detrás de una cobertura." +
                    "El arma usa un supresor integral, por lo que es codiciada por los habitantes de la Zona que prefieren disparar y luego preguntar...", "r2"));

                    listaArmas.Add(new Arma("G3", "Heckler & Koch", Arma.Tipo.Rifle, "El Heckler & Koch G3 es un fusil de combate fabricado por la empresa alemana Heckler & Koch, " +
                    "en colaboración con la empresa estatal española CETME (Centro de Estudios Técnicos de Materiales Especiales). Conocido como el rifle de batalla definitivo, y con más de 7 millones de unidades fabricadas hasta 1997," +
                    " aún hoy en día se lo puede ver por la Zona", "r3"));
                break;
                case Soldado.ClaseSoldado.Tecnico:
                    listaArmas.Add(new Arma("M1911", "Colt", Arma.Tipo.Pistola,
                    "La automática definitiva. La M1911 es una pistola semiautomática de acción simple, " +
                    "alimentada por cargador, operada por retroceso directo y que dispara el cartucho .45 ACP.1​ " +
                    "Fue el arma auxiliar de dotación del Ejército estadounidense desde 1911 hasta 1985. " +
                    "Tuvo uso extendido en la Primera Guerra Mundial, Segunda Guerra Mundial, en la Guerra de Corea y en la Guerra de Vietnam. " +
                    "La M1911 aún hoy es portada por algunas fuerzas de la OTAN, y por su resiliencia y precisión es un arma apreciada en la Zona", "p1"));

                    listaArmas.Add(new Arma("Desert Eagle", "IMI", Arma.Tipo.Pistola, "La Desert Eagle es una pistola semiautomática de grueso calibre accionada por los gases del disparo, diseñada por la firma estadounidense Magnum Research " +
                    "y fabricada principalmente en Israel por IMI (Industrias Militares de Israel), ahora Israel Weapons Industry. " +
                    "Debido a su silueta fácilmente reconocible y a sus cartuchos de grueso calibre, la Desert Eagle se ha convertido en un arma casi arquetípica en la cultura popular. " +
                    "Su potencia de fuego es suficiente para ​incapacitar a cualquier adversario encontrado en la Zona, sea humano o no...", "p2"));

                    listaArmas.Add(new Arma("Makarov PM", "Fábrica Mecánica de Izhevsk", Arma.Tipo.Pistola, "La Makárov PM (Pistolet Makárova, en ruso, Пистолет Макарова ПМ) es una pistola semiautomática diseñada a finales de los 40, " +
                    "por Nikolái Fyódorovich Makárov, y fue el arma auxiliar militar estándar de las naciones del Pacto de Varsovia de 1951 a 1991. Confiable y barata, es común encontrarsela en la Zona", "p3"));
                    break;

            }
    
            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.indice++;
            ActualizarEstadoBotonesNavegacion();
            ImprimirDatosArma();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.indice--;
            ActualizarEstadoBotonesNavegacion();
            ImprimirDatosArma();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.nuevoSoldado.Arma = listaArmas[indice];
            this.Close();
        }
    }
}
