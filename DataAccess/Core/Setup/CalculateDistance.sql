USE [Dev]
GO

/****** Object:  UserDefinedFunction [dbo].[CalculateDistance]    Script Date: 4/7/2020 16:29:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CalculateDistance]
                                                (
                                                    @Lat1 FLOAT,
                                                   @Lon1 FLOAT,
                                                    @Lat2 FLOAT,
                                                    @Lon2 FLOAT
                                                )
                                                RETURNS FLOAT
                                                AS
                                                BEGIN
                                                    DECLARE @rlat1 FLOAT
                                                   DECLARE @rlat2 FLOAT
                                                    DECLARE @theta FLOAT
                                                    DECLARE @rtheta FLOAT
                                                    DECLARE @dist FLOAT

                                                    SET @rlat1 = PI() * @Lat1 / 180
                                                    SET @rlat2 = PI() * @Lat2 / 180
                                                    SET @theta = @Lon1 - @Lon2
                                                    SET @rtheta = PI() * @theta / 180;
                                                    SET @dist = SIN(@rlat1) * SIN(@rlat2) + COS(@rlat1) * COS(@rlat2) * COS(@rtheta)
                                                    SET @dist = ACOS(@dist)
                                                    SET @dist = @dist * 180 / PI()
                                                    SET @dist = @dist * 60 * 1.1515

                                                    RETURN @dist *16.09344;
                                                END
GO

