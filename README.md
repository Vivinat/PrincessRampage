<p align="center" width="100%">
    <img width="55%" src="/TrabalhoFinal_POO2/Assets/Intro/Intro_Movie/Menu_Panel.png">
</p>

Princess Rampage foi um jogo produzido para o trabalho final da disciplina Programação Orientada a Objetos II, ministrada pelo professor Phyllipe Lima.
O jogo é um 2D Top-Down Wave-Based Shooter que foi produzido por meio da engine Unity e escrito em C#. 
Este trabalho possui um grande foco na utilização de Design Patterns.

# 🐱‍💻 Instalação

O arquivo executável do jogo pode ser baixado no link a seguir : [Princess Rampage](https://vivinat-corporation.itch.io/princess-rampage). 
Apesar de ser possível jogá-lo a partir do download do repositório, o arquivo deverá ser aberto na [Unity versão 2021.3.3f1](https://unity.com/releases/editor/whats-new/2021.3.3), e pode ser jogado no modo de PlayTest ou numa build separada.

# 👾 Sobre o Jogo

<p align="center" width="100%">
    <img width="2%" src="/TrabalhoFinal_POO2/Assets/Player_Sprites/Bald.png">
</p>

Após ter sido amaldiçoada por uma bruxa com um problema capilar (Careca), a princesa Phillima precisa realizar um ritual para impedir que seus belos cabelos caiam!
Use da magia da princesa para abater os asseclas da bruxa, e acabe com ela para finalizar o ritual!
Além das mecânicas de disparo, o jogo conta com as seguintes mecânicas:

- Timer para abater o máximo possível de inimigos e sobreviver;
- Sistema de drops que fornecem desde curas até efeitos permanentes nos atributos;
- Sistema de Level-Up aleatório;
- "Endless Mode", onde o objetivo é sobreviver o máximo de tempo possível enquanto hordas intermináveis de inimigos o atacam.
- Sistema de Score e HighScore no EndlessMode

# 🧠 As Design Patterns

Foram utilizadas as seguintes Design Patterns no processo de desenvolvimento do jogo:

## 🦥 Singleton
O Singleton é um padrão de projeto criacional, que garante que apenas um objeto desse tipo exista e forneça um único ponto de acesso a ele para qualquer outro código. O Singleton tradicionalmente é definido na função Awake (Função executada na inicialização de objetos do jogo). Destacam-se no projeto, o uso dos Singletons Game_Controller e AudioManager, o primeiro sendo responsável pela condução e armazenamento de funções e dados que dizem respeito ao player (Atributos e funções que envolvem suas manipulações), e o segundo, responsável pela reprodução e controle de efeitos sonoros do jogo.

````
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GameObject);
            return;
        }
    }
````


## 🤖 Finite State Machine (FSM)
A Finite State Machine é um sistema de comportamentos definido por Enums, o que permite a criação a troca rápida entre comportamentos. A FSM foi utilizada para o desenvolvimento da IA dos inimigos.


## 👀 Observer
O Observer define uma dependência “um para muitos”. Quando um objeto mudar de estado (subject/observável), todos os seus dependentes são notificados automaticamente. Este pattern foi implementado para ser utilizado em dois casos:

- No modo de jogo Endless Mode existe um contador de pontos, que aumenta sempre que o player mata um inimigo. Existe um script responsável por esse contador que implementa a interface de Observador (IObs). Esse script implementa a função UpdateObs, que recebe uma referência para o inimigo (observável) e o seu estado atual. Se o estado do inimigo é "Die", significa que ele morreu e que a quantidade total de pontos devem ser incremetada. Cada inimigo fornece uma quantidade de pontos que é 10x maior que o valor do seu dano (ou seja, quanto mais forte for o inimigo que o player matou, mais pontos ele acumula).
  A interface do Observável é o script do inimigo quem implementa. Cada novo inimigo instanciado no jogo registra o contador para que possa notificá-lo de sua morte no final. Quando morre, o inimigo chama a função Notify para avisar os observadores (o contador, nesse caso) de que ele morreu para que o contador possa executar suas instruções.

````
    namespace DefaultNamespace
    {
        public interface IObs
        {
            public void updateObs(ISubj subject, EnemyState state);
        }
    }
````
````
    namespace DefaultNamespace
    {
        public interface ISubj
        {
            void register(IObs obs);
            void unregister(IObs obs);
            void notify(ISubj subj, EnemyState state);
        }
    }
````

- Na fase "Final Boss" houve a necessidade de mostrar a quantidade de vida restante do Boss, ja que ele é o mais difícil. Quando o inimigo é o Boss ele registra a barra de vida como um de seus observadores e a notifica de que nasceu na cena para que a vida máxima dela seja calculada. A barra de vida é então notificada sempre que o Boss recebe algum dano. Ela recebe a instância do Boss e o seu estado (que nesse caso será Damage. É feito então o cálculo do dano para diminuir a barra de vida de acordo com o dano que recebeu.

## 🚧 Concurrency (Corrotinas)
Sendo uma design pattern de Concorrência, as Corrotinas (Coroutines) são métodos que que podem ser usados para pausar a execução em determinada parte do código, geralmente utilizado para contabilizar tempo e retornar um resultado após este tempo ter se esgotado. Corrotinas foram utilizadas no jogo para determinar o tempo em que os inimigos piscam após receberem dano, e o tempo de duração do disparo executado pelo player, entre outros. 

````
    void Start()
    {
        gameController = FindObjectOfType<Game_Controller>();
        StartCoroutine(DeathDelay()); //Coroutine para saber quando destruimos a bala
    }
````

````
    IEnumerator DeathDelay(){
        yield return new WaitForSeconds(lifeTime);  //Espere a quantidade de tempo definido por lifeTime
        Destroy(gameObject);       //Depois, destrua o objeto (a bala)
    }
````

# ❤ Créditos e Agradecimentos
Agradecimentos especiais para os artistas que compartilharam suas artes:

🤝 [FlandreScarlet64](https://flandrescarlet64.itch.io/16x16-16-bits-top-down-mage-character)     
🤙 [3xBlast](https://opengameart.org/content/16bit-boss-battle-loop)  
👍 [Spring Spring](https://opengameart.org/content/the-king-of-hell-final-boss-theme)  
💗 [jkfite01](https://opengameart.org/content/peaceful-village-16-bit)  
💪 [Redshrike](https://opengameart.org/content/16x16-16x24-32x32-rpg-enemies-updated)  
🙏 [request](https://opengameart.org/content/their-spears-fell-like-rain-loopable-chiptune-battle-theme)  
🤜 [RedSteve](https://redsteve.itch.io/top-down-dungeon-tileset)  

Quaisquer outras artes que não foram aqui citadas foram produzidas de forma original ou, se sua arte foi usada, peço que entre em contato para que possa ser fornecido os devidos créditos.

#  Autores
[Vinicius Vieira Mota](https://github.com/Vivinat)              
[Augusto Lázaro](https://github.com/augustolr06)                
[Matheus Rodrigues Pronunciate](https://github.com/MatheusPronunciate)             
[Guilhermesf27](https://github.com/Guilhermesf27)              


🎮👨‍🦲 Projeto desenvolvido para a disciplina POO2 do Professor [Phyllipe Lima](https://github.com/phillima). 




