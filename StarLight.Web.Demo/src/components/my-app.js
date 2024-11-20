"use client";
// pages/_app.js
import React from 'react';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { CacheProvider } from '@emotion/react';
import createCache from '@emotion/cache';
import { Box, Container } from '@mui/material';

const theme = createTheme({
    palette: {
        mode: 'dark',
    },
});

const cache = createCache({
    key: 'css',
    prepend: true,
});

export default function MyApp({ children }) {
    return (
        <div class="main-background">
            <CacheProvider value={cache}>
                <ThemeProvider theme={theme}>
                    <CssBaseline />
                    <Container maxWidth="md">
                        <Box my={4}>
                            {children}
                        </Box>
                    </Container>
                </ThemeProvider>
            </CacheProvider>
        </div>
    );
}