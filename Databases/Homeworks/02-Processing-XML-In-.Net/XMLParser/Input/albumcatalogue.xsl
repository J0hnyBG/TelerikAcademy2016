<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <body>
                <h1>Albums</h1>
                <xsl:for-each select="albumCatalogue/album">
                    <div>
                        <p>
                            <strong>Name:</strong>
                            <xsl:value-of select="name"/>
                        </p>
                        <p>
                            <strong>Artist:</strong>
                            <xsl:value-of select="artist"/>
                        </p>
                        <p>
                            <strong>Year:</strong>
                            <xsl:value-of select="year"/>
                        </p>
                        <p>
                            <strong>Producer:</strong>
                            <xsl:value-of select="producer"/>
                        </p>
                        <p>
                            <strong>Price: </strong>
                            <xsl:value-of select="price"/>
                        </p>
                        <xsl:for-each select="songs">
                            <h3>Song list</h3>
                            <dl>
                                <xsl:for-each select="song">
                                    <dt>Title: <xsl:value-of select="title"/></dt>
									 <dd><em>Duration: <xsl:value-of select="length"/></em></dd>
                                </xsl:for-each>
                            </dl>
                        </xsl:for-each>
                    </div>
                    <hr/>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>