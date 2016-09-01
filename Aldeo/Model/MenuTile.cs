using System;

namespace Aldeo.Model {
    public class MenuTile {
        public string Title { get; private set; }
        public char Icon { get; private set; }
        public string Tag { get; private set; }

        public MenuTile(char icon, string title) {
            Icon = icon;
            Title = title;
            Tag = title;
        }

        public MenuTile(char icon, string title, string tag) : this (icon, title) {
            Tag = tag;
        }
    }
}