<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:s="urn:students">
    <xsl:template match="/">
        <html>
            <body>
                <h1>University Students</h1>
                <xsl:for-each select="s:university/s:student">
                    <div>
                        <p>
                            <strong>Name:</strong>
                            <xsl:value-of select="s:name"/>
                        </p>
                        <p>
                            <strong>Gender:</strong>
                            <xsl:value-of select="s:gender"/>
                        </p>
                        <p>
                            <strong>Birth Date:</strong>
                            <xsl:value-of select="s:birthDate"/>
                        </p>
                        <p>
                            <strong>Phone:</strong>
                            <xsl:value-of select="s:phone"/>
                        </p>
                        <p>
                            <strong>E-mail:</strong>
                            <xsl:value-of select="s:email"/>
                        </p>
                        <p>
                            <strong>Course:</strong>
                            <xsl:value-of select="s:course"/>
                        </p>
                        <p>
                            <strong>Specialty:</strong>
                            <xsl:value-of select="s:specialty"/>
                        </p>
                        <p>
                            <strong>Faculty Number:</strong>
                            <xsl:value-of select="s:facultyNumber"/>
                        </p>
                        <xsl:for-each select="s:exams">
                            <h3>Student exams</h3>
                            <ul>
                                <xsl:for-each select="s:exam">
                                    <li>Subject:
                                        <xsl:value-of select="s:name"/>
                                        <ul>
                                            <li>Tutor:
                                                <xsl:value-of select="s:tutor"/>
                                            </li>
                                            <li>Score:
                                                <xsl:value-of select="s:score"/>
                                            </li>
                                        </ul>
                                    </li>
                                </xsl:for-each>
                            </ul>
                        </xsl:for-each>
                        <xsl:for-each select="s:enrollment">
                            <p>The student has enrolled on
                                <xsl:value-of select="s:date"/> with an exam score of <xsl:value-of
                                        select="s:examScore"/>.
                            </p>
                        </xsl:for-each>
                    </div>
                    <hr/>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>