<section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, &#xD;&#xA;             Microsoft.Practices.Unity.Configuration" />

 <!-- DEBUT de la configuration Unity - DEBUT -->
<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
	<sectionExtension type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension, Microsoft.Practices.Unity.Interception.Configuration" />
		<container>    
			<extension type="Interception" />
			<types>
				<type type="BDV.POC.ArticleLog.Loggers.ILogManager, BDV.POC.ArticleLog.Loggers.Contracts" mapTo="BDV.POC.ArticleLog.Loggers.NLogProvider.LogManagerForNLog, BDV.POC.ArticleLog.Loggers">
				</type>
				<type type="Press.Business.Interfaces.IBusinessLogic,Press.Business.Interfaces" mapTo="Press.Business.BusinessLogic,Press.Business">
				</type>
				<type type="Press.DataAccess.Interfaces.IDataAccess,Press.DataAccess.Interfaces" mapTo="Press.SQLServer.DataAccess.DataAccess,Press.SQLServer.DataAccess">
					<interceptor type="InterfaceInterceptor" />
					<interceptionBehavior type="BDV.POC.ArticleLog.Loggers.LoggerInterceptionBehavior, BDV.POC.ArticleLog.Loggers.UnityExtensions" />
				</type>
				<type type="LinqToSQLMvcApplication.Controllers.HomeController,LinqToSQLMvcApplication">
				</type>
				<type type="LinqToSQLMvcApplication.Controllers.BookController,LinqToSQLMvcApplication">
				</type>
				<type type="LinqToSQLMvcApplication.Controllers.PublisherController,LinqToSQLMvcApplication">
				</type>
			</types>
		</container>
</unity>