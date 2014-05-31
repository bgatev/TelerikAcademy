namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media.Media3D;

    public abstract class Surface : ModelVisual3D
    {
        public static PropertyHolder<Material, Surface> MaterialProperty = new PropertyHolder<Material, Surface>("Material", null, OnMaterialChanged);
        public static PropertyHolder<Material, Surface> BackMaterialProperty = new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);
        public static PropertyHolder<bool, Surface> VisibleProperty = new PropertyHolder<bool, Surface>("Visible", true, OnVisibleChanged);

        private readonly GeometryModel3D _content = new GeometryModel3D();

        public Surface()
        {
            Content = _content;
            _content.Geometry = CreateMesh();
        }

        public Material Material
        {
            get { return MaterialProperty.Get(this); }
            set { MaterialProperty.Set(this, value); }
        }

        public Material BackMaterial
        {
            get { return BackMaterialProperty.Get(this); }
            set { BackMaterialProperty.Set(this, value); }
        }

        public bool Visible
        {
            get { return VisibleProperty.Get(this); }
            set { VisibleProperty.Set(this, value); }
        }

        protected static void OnGeometryChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        protected abstract Geometry3D CreateMesh();

        private static void OnMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnBackMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        private void OnMaterialChanged()
        {
            SetContentMaterial();
        }

        private void OnBackMaterialChanged()
        {
            SetContentBackMaterial();
        }

        private void OnVisibleChanged()
        {
            SetContentMaterial();
            SetContentBackMaterial();
        }

        private void SetContentMaterial()
        {
            _content.Material = Visible ? Material : null;
        }

        private void SetContentBackMaterial()
        {
            _content.BackMaterial = Visible ? BackMaterial : null;
        }

        private void OnGeometryChanged()
        {
            _content.Geometry = CreateMesh();
        }
    }
}
