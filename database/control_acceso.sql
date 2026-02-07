CREATE DATABASE  IF NOT EXISTS `control_acceso` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `control_acceso`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: control_acceso
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tipo_usuario`
--

DROP TABLE IF EXISTS `tipo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_usuario` (
  `TIP_CVE_TIPOUSUARIO` int NOT NULL AUTO_INCREMENT,
  `TIP_DESCRIPCION` varchar(20) NOT NULL,
  PRIMARY KEY (`TIP_CVE_TIPOUSUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_usuario`
--

LOCK TABLES `tipo_usuario` WRITE;
/*!40000 ALTER TABLE `tipo_usuario` DISABLE KEYS */;
INSERT INTO `tipo_usuario` VALUES (1,'Administrador'),(2,'Supervisor'),(3,'Operativo'),(4,'Administrador'),(5,'Supervisor'),(6,'Operativo');
/*!40000 ALTER TABLE `tipo_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `USU_CVE_USUARIO` int NOT NULL AUTO_INCREMENT,
  `USU_NOMBRE` varchar(20) NOT NULL,
  `USU_APELLIDO_PATERNO` varchar(20) NOT NULL,
  `USU_APELLIDO_MATERNO` varchar(20) NOT NULL,
  `USU_USUARIO` varchar(20) NOT NULL,
  `USU_CONTRASENA` varchar(20) NOT NULL,
  `USU_RUTA` varchar(200) NOT NULL,
  `TIP_CVE_TIPOUSUARIO` int NOT NULL,
  PRIMARY KEY (`USU_CVE_USUARIO`),
  KEY `TIP_CVE_TIPOUSUARIO` (`TIP_CVE_TIPOUSUARIO`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`TIP_CVE_TIPOUSUARIO`) REFERENCES `tipo_usuario` (`TIP_CVE_TIPOUSUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (2,'Ana','Zúñiga','Mendoza','lbell','123','imagenes/fotos/2.jpg',3),(3,'Roberto','Ruiz','Aguirre','rruiz','isc2025','imagenes/fotos/3.jpg',3),(5,'Maria','Lopez','Diaz','mlopez','pass2025','imagenes/fotos/5.jpg',2),(7,'Camila','Suarez','Sanchez','csuarez','pass2025','imagenes/fotos/7.jpg',1),(8,'Tonali','Martinez','Aldama','tmartinez','pass2025','imagenes/fotos/8.jpg',2),(9,'Andrea','Reyes','Sanchez','areyes','pass2025','imagenes/fotos/9.jpg',3),(10,'Monica','Rosales','Mendoza','mrosales','pass2025','imagenes/fotos/10.jpg',1),(11,'juan','Rios','Mendoza','sescamilla','nueva2025','imagenes/fotos/11.jpg',2),(12,'Ricardo','Rios','Hernandez','rrios','pass2025','imagenes/fotos/12.jpg',3),(13,'Braulio','Vazquez','Lopez','bvazquez','pass2025','imagenes/fotos/13.jpg',1),(14,'Jorge Luis','Ponce','Sandoval','Sandoval33','itp2024','imagenes/2.jpg',2),(15,'Juan','Escamilla','Mendoza','ricardo2823','itp2025','imagenes/34.jpg',2),(16,'monica','escamilla','mendoza','mescamilla','isc2025','imagenes/2.jpg',2),(17,'Dilan','Monrroy','Gonzalez','dmonrroy','itp2025','imagenes/twitter.png',3),(21,'Norma Angeliza','Mendoza','Gutierrez','namg','123','imagenes/fotos/25.jpg',5);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vwrptusuario`
--

DROP TABLE IF EXISTS `vwrptusuario`;
/*!50001 DROP VIEW IF EXISTS `vwrptusuario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vwrptusuario` AS SELECT 
 1 AS `Clave`,
 1 AS `Nombre`,
 1 AS `Usuario`,
 1 AS `Foto`,
 1 AS `Rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vwtipousuario`
--

DROP TABLE IF EXISTS `vwtipousuario`;
/*!50001 DROP VIEW IF EXISTS `vwtipousuario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vwtipousuario` AS SELECT 
 1 AS `clave`,
 1 AS `descripcion`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'control_acceso'
--
/*!50003 DROP PROCEDURE IF EXISTS `spDelUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spDelUsuario`(
clave	INT
)
BEGIN
       IF EXISTS (SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_CVE_USUARIO = clave) THEN 
		-- SE PROCEDE A BORRAR
		DELETE FROM USUARIO WHERE USUARIO.USU_CVE_USUARIO = clave;
		SELECT '0';
         ELSE
		SELECT '1';
       END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spInsUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsUsuario`(
IN nombre	varchar(20),
IN paterno	varchar(20),
IN materno	varchar(20),
IN usuario	varchar(20),
IN contrasena	varchar(20),
IN ruta		varchar(200),
IN tipo		int
)
BEGIN
	-- 1ERA VALIDACION
	IF NOT EXISTS(SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_NOMBRE = nombre 
			  AND   USU_APELLIDO_PATERNO = paterno
			  AND   USU_APELLIDO_MATERNO = materno ) THEN
		-- 2DA VALIDACION
		IF NOT EXISTS(SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_USUARIO = usuario) THEN

			-- 3ERA VALIDACION
			IF EXISTS(SELECT TIP_CVE_TIPOUSUARIO FROM TIPO_USUARIO WHERE TIP_CVE_TIPOUSUARIO = tipo) THEN
				-- VALIDACIONES CORRECTAS, SE PROCEDE A INSERTAR REGISTRO
				INSERT INTO USUARIO VALUES(null, nombre, paterno, materno, usuario, contrasena, ruta, tipo);
				SELECT '0';
			ELSE
				-- NO EXISTE EL TIPO DE USUARIO EN TABLA TIPO_USUARIO
				SELECT '3';
			END IF;

		ELSE
			-- SI EXISTE UN USUARIO REGISTRADO CON EL PARAMETRO RECIBIDO
			SELECT '2';
		END IF;

	ELSE
		-- SI EXISTE UN USUARIO CON EL NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO REGISTRADO
		SELECT '1';
	END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdUsuario`(
clave		INT,
nombre		VARCHAR(20),
paterno		VARCHAR(20),
materno		VARCHAR(20),
usuario		VARCHAR(20),
pwd		VARCHAR(20),
ruta		VARCHAR(200),
tipo		INT
)
BEGIN
    -- 1ER VALIDACION
    IF  EXISTS (SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_CVE_USUARIO = clave) THEN

         -- 2DA VALIDACION
         IF NOT EXISTS (SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_NOMBRE = nombre
				AND  USU_APELLIDO_PATERNO = paterno
				AND  USU_APELLIDO_MATERNO = materno ) THEN
              -- 3ERA VALIDACION 
              IF NOT EXISTS (SELECT USU_CVE_USUARIO FROM USUARIO WHERE USU_USUARIO = usuario) THEN
              
                  -- 4TA VALIDACION
                  IF EXISTS (SELECT  TIP_CVE_TIPOUSUARIO FROM TIPO_USUARIO WHERE TIP_CVE_TIPOUSUARIO = tipo ) THEN
                       
                       -- SE PROCEDE A ACTUALIZAR  

                       UPDATE  USUARIO SET 
                       USU_NOMBRE              	= nombre, 
                       USU_APELLIDO_PATERNO    	= paterno, 
                       USU_APELLIDO_MATERNO    	= materno,
                       USU_USUARIO            	= usuario,
                       USU_CONTRASENA          	= pwd,
                       USU_RUTA                	= ruta, 
                       TIP_CVE_TIPOUSUARIO     	= tipo
                       WHERE USU_CVE_USUARIO	= clave;
                       SELECT '0';
                   ELSE
                       SELECT '4';
                   END IF;
              ELSE
                   SELECT '3';
              END IF;     
        ELSE
             SELECT '2';
        END IF;
    ELSE
        SELECT '1';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spValidarAcceso` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spValidarAcceso`(
in usuario	varchar(20),
in contrasena	varchar(20)
)
begin
	if exists(	select	concat(u.usu_nombre, ' ', u.usu_apellido_paterno, ' ', u.usu_apellido_materno) 
				as usu_nombre_completo,
				u.usu_ruta, u.usu_usuario, t.tip_descripcion
			from	usuario u, tipo_usuario t
			where	u.tip_cve_tipousuario = t.tip_cve_tipousuario
			and	u.usu_usuario = usuario
			and     u.usu_contrasena = contrasena  ) then
		select	'1', 
			concat(u.usu_nombre, ' ', u.usu_apellido_paterno, ' ', u.usu_apellido_materno) 
			as usu_nombre_completo,
			u.usu_ruta, u.usu_usuario, t.tip_descripcion
		from	usuario u, tipo_usuario t
		where	u.tip_cve_tipousuario = t.tip_cve_tipousuario
		and	u.usu_usuario = usuario
		and     u.usu_contrasena = contrasena;
	else
		select '0';
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vwrptusuario`
--

/*!50001 DROP VIEW IF EXISTS `vwrptusuario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vwrptusuario` AS select `u`.`USU_CVE_USUARIO` AS `Clave`,concat(`u`.`USU_NOMBRE`,' ',`u`.`USU_APELLIDO_PATERNO`,' ',`u`.`USU_APELLIDO_MATERNO`) AS `Nombre`,`u`.`USU_USUARIO` AS `Usuario`,`u`.`USU_RUTA` AS `Foto`,concat(`t`.`TIP_CVE_TIPOUSUARIO`,'-',`t`.`TIP_DESCRIPCION`) AS `Rol` from (`usuario` `u` join `tipo_usuario` `t`) where (`u`.`TIP_CVE_TIPOUSUARIO` = `t`.`TIP_CVE_TIPOUSUARIO`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vwtipousuario`
--

/*!50001 DROP VIEW IF EXISTS `vwtipousuario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vwtipousuario` AS select `t`.`TIP_CVE_TIPOUSUARIO` AS `clave`,concat(`t`.`TIP_CVE_TIPOUSUARIO`,'-',`t`.`TIP_DESCRIPCION`) AS `descripcion` from `tipo_usuario` `t` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-01-21 16:34:21
