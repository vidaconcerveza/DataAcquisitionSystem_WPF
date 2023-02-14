using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFramework
{

    //IoC = Inversion of Control 제어역전
    //
    //ViewModelLocator.
    //MVVM Pattern을 초기화 하는 방법은 10가지 정도 패턴이 있음.
    //VisualStudio의 DesignTime에 잘 보이게 하려면 ViewModelLocator를 넣는게 가장 좋음.
    //중복을 피하고 싶은 컨트롤마다 로케이터가 생성이 될 필요는 없고, 사전에 미리 정의. 
    //IoC Container는 싱글턴으로, 사용자가 등록한 타입별 인스턴스를 관리하는 일인데,
    //IoC Container를 사용함으로 프로그램 어느 곳에서나 타입만 지정하면 그 타입의 동일 인스턴스를 얻을수 있음
    //즉, ViewModelLocator를 모든 컨트롤에서 매번 생성해도 아무 문제가 없음...

    public static class IoC
    {
        //Gets an instance by type and key.
        public static Func<Type, string, object> GetInstance = (service, key) =>
        {
            throw new InvalidOperationException("IoC is not Initialized");
        };

        //Gets all instances of a particular type.
        public static Func<Type, IEnumerable<object>> GetAllInstances = (service) =>
        {
            { throw new InvalidOperationException("IoC is not Initialized."); }
        };

        //Passes an Existing instance to the IoC Container to enable dependencies to be injected.
        public static Action<object> BuildUp = (instance) =>
        {
            { throw new InvalidOperationException("IoC is not initialized."); }
        };



        //GetInstance From the Container
        public static T Get<T>(string key = null)
        {
            return (T)GetInstance(typeof(T), key);
        }

        public static object Get(Type type, string key = null)
        {
            return GetInstance(type, key);
        }

        //Get all instances of a particular type.
        public static IEnumerable<T> GetAll<T>()
        {
            return GetAllInstances(typeof(T)).Cast<T>();
        }
    }
}
