// loading.js
import React, { useState, useEffect } from 'react';
import { Container, Typography, Box, CircularProgress, Grid, Grid2 } from '@mui/material';
import EmojiEmotionsIcon from '@mui/icons-material/EmojiEmotions';
import SentimentVerySatisfiedIcon from '@mui/icons-material/SentimentVerySatisfied';
import MoodIcon from '@mui/icons-material/Mood';

const jokes = [
    "Why did the React developer go broke? Because they lost their state!",
    "Why do React developers prefer using hooks? Because class components are so last season!",
    "Why did the component feel lost? Because it didn't know how to handle its state!",
    "Why do React developers love functions? Because they always return something!",
    "Why did the React developer stay calm? Because they had a handle on their state!",
    "Why did the React developer bring a ladder to work? To reach the highest component!",
    "Why did the React developer get a promotion? Because they knew how to handle props!",
    "Why did the React developer go to therapy? To deal with their state of mind!",
    "Why did the React developer get a pet? To learn about lifecycle methods!",
    "Why did the React developer get a new job? Because they wanted to hook up with a new company!"
];

const LoadingPage = () => {
    const [currentJoke, setCurrentJoke] = useState(jokes[0]);

    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentJoke(jokes[Math.floor(Math.random() * jokes.length)]);
        }, 3000); // Change joke every 1.5 seconds

        return () => clearInterval(interval); // Cleanup interval on component unmount
    }, []);
    return (
        <Container maxWidth="sm" sx={{ textAlign: 'center', mt: 10 }}>
            <Box>
                <Typography variant="h4" component="h1" gutterBottom>
                    Loading... Please Wait!
                </Typography>
                <CircularProgress size={60} thickness={5} />
                <Typography variant="h6" component="p" gutterBottom sx={{ mt: 2 }}>
                    We're fetching the best content for you!
                </Typography>
                <Grid2 container spacing={2} justifyContent="center" alignItems="center" sx={{ mt: 4 }}>
                    <EmojiEmotionsIcon color="primary" style={{ fontSize: 50 }} />
                    <SentimentVerySatisfiedIcon color="secondary" style={{ fontSize: 50 }} />
                    <MoodIcon color="success" style={{ fontSize: 50 }} />
                </Grid2>
                <Typography variant="h2" component="p" sx={{ mt: 4 }}>
                    {currentJoke}
                </Typography>
            </Box>
        </Container>
    );
};

export default LoadingPage;