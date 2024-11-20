// error.js
import React from 'react';
import Image from 'next/image'
import { Container, Typography, Box, Button, Grid2 } from '@mui/material';
import SentimentVeryDissatisfiedIcon from '@mui/icons-material/SentimentVeryDissatisfied';
import BugReportIcon from '@mui/icons-material/BugReport';

const ErrorMessage = ({ error }) => (
    <Container maxWidth="sm" sx={{ textAlign: 'center', mt: 10 }}>
        <Box>
            <SentimentVeryDissatisfiedIcon color="error" style={{ fontSize: 100 }} />
            <Typography variant="h4" component="h1" gutterBottom>
                Oops! Something went wrong.
            </Typography>
            <Typography variant="h6" component="p" gutterBottom>
                It looks like we encountered an unexpected error.
            </Typography>
            <Box sx={{ display: 'flex', justifyContent: 'center', mt: 4 }}>
                <Image src="/img/fail.webp" alt="Funny fail" width="200" height="100" />
            </Box>
            <Grid2 container spacing={2} justifyContent="center" alignItems="center" sx={{ mt: 4 }}>
                <Grid2>
                    <BugReportIcon color="primary" style={{ fontSize: 50 }} />
                </Grid2>
                <Grid2>
                    <Typography variant="body1" component="p" sx={{ textAlign: 'left' }}>
                        Error Code: {error.status}
                    </Typography>
                    <Typography variant="body1" component="p" sx={{ textAlign: 'left' }}>
                        Message: {error.message}
                    </Typography>
                </Grid2>
            </Grid2>
        </Box>
    </Container>
);
export default ErrorMessage;