using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpfka
{
    public partial class MainWindow : Window
    {

        private Dictionary<string, int> objects;
        public MainWindow()
        {
            InitializeComponent();

            objects = new Dictionary<string, int>()
            {
             {"Русский язык",5},
             {"Литература",4},
             {"Математика",3},
             {"Физ-ра",2},
             {"ИЗО",4},
             {"Физика",5},
             {"Химия",3},
             {"История",5},
             {"ОБЖ",4},
             {"География",3}};
            
        }
        private void source_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст из TextBox
            string subject = name.Text.Trim();

            // Проверяем наличие предмета в словаре
            if (objects.TryGetValue(subject, out int grade))
            {
                // Если найден, выводим предмет и его оценку
                Elem.Text = $"Предмет: {subject}, Оценка: {grade}";
            }
            else
            {
                // Если не найден, выводим сообщение об ошибке
                Elem.Text = "Ключ не найден.";
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string subject = name.Text.Trim();

            if (objects.Remove(subject))
            {
                Elem.Text = $"Предмет '{subject}' удален.";
            }
            else
            {
                Elem.Text = "Ключ не найден для удаления.";
            }
        }

        private void deleteall_Click(object sender, RoutedEventArgs e)
        {
            objects.Clear();
            Elem.Text = "Все предметы удалены.";
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            all.Text = string.Join(Environment.NewLine, objects.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }
    }
}
