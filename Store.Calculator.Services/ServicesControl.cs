using Store.Calculator.Services.Handlers;

namespace Store.Calculator.Services
{
    public class ServicesControl
    {

        public ServicesControl(IMaterialHandler materialHandler, IValorServicoHandler valorServicoHandler)
        {
            this.materialHandler = materialHandler;
            this.valorServicoHandler = valorServicoHandler;
        }

        public IMaterialHandler materialHandler { get; set; }

        public IValorServicoHandler valorServicoHandler { get; set; }
    }
}
