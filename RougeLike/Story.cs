﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class Story
    {
        public Story()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Безымянный рыцарь, держа в руке меч прорывается через запутанные подземелья, " +
                "чтобы спасти принцессу. Перед его взором огромный зал-лабиринт, кишащий опасными тварями. " +
                "Вроде бы это последний этаж башни, на вершине которой герой сможет найти заточённую девушку.");
            Console.WriteLine("После изнуряющей битвы он уже не помнил ничего, кроме одной, крошечной мысли – " +
                "зачем он пошел в это место… Когда королевство процветало, все жили в мире и порядке. " +
                "Вот уже двести лет людям этого славного места не приходилось брать холодную сталь в руки. " +
                "Но однажды в наш мир нагрянули бесчисленные полчища монстров. " +
                "Сражаться с ними теперь вопрос жизни и смерти.");
            Console.WriteLine("И вот последние испытание рыцаря. Несмотря на невыносимую усталость, " +
                "он с ещё большей силой вцепился в меч почти мёртвой хваткой. " +
                "Это всем понятно, ведь у никому неизвестного рыцаря всего дня цель – спасти свою дочь. ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.WriteLine("-------------------------------------");
            Console.ReadKey(true);
        }
    }
}