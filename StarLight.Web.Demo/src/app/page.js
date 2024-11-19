import React from 'react';
import { Container, Typography, Box, List, ListItem, ListItemText, AppBar, Toolbar, ListItemIcon, Card, CardContent, Grid, Grid2, Link, Button } from '@mui/material';
import { CallSplit, RocketLaunch, SmartButton } from '@mui/icons-material';

export default function Home() {
  return (
      <>
        <Typography variant="h3" component="h1" gutterBottom>
          Tips for making a solid react app
        </Typography>
        <List>
          <ListItem>
            <ListItemIcon>
              <CallSplit color="primary" />
            </ListItemIcon>
            <ListItemText>
              Split your library into dumb components and smart components. Dumb components are presentational and don't manage state, while smart components handle state and logic.
            </ListItemText>
          </ListItem>
          <ListItem>
            <ListItemIcon>
              <SmartButton color="primary" />
            </ListItemIcon>
            <ListItemText>
              Use hooks like `useState` and `useEffect` to manage state and side effects in functional components.
            </ListItemText>
          </ListItem>
          <ListItem>
            <ListItemIcon>
              <RocketLaunch color="primary" />
            </ListItemIcon>
            <ListItemText>
              Optimize performance by using React.memo, useCallback, and useMemo where appropriate.
            </ListItemText>
          </ListItem>
        </List>
        <nav>
          <Grid2 container spacing={2}>
            <Link href="regular">
              <Card>
                <CardContent>
                  <Typography gutterBottom variant="h5" component="div">
                    See Regular Example
                  </Typography>
                  <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                    Click on this one to see the regular api loading speed
                  </Typography>
                </CardContent>
              </Card>
            </Link>
            <Link href="/slow">
              <Card>
                <CardContent>
                  <Typography gutterBottom variant="h5" component="div">
                    See Slow Example
                  </Typography>
                  <Typography variant="body2" sx={{ color: 'text.secondary' }}>
                    Click on this one to see the slow example
                  </Typography>
                </CardContent>
              </Card>
            </Link>
          </Grid2>
          <List>
            <ListItem button component={Link} href="/about">
              <ListItemText primary="About" />
            </ListItem>
            <ListItem button component={Link} href="/contact">
              <ListItemText primary="Contact" />
            </ListItem>
          </List>
        </nav>
      </>
  );
}