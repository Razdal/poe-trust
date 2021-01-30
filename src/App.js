import { Box, Button, Flex, Grid, Input, Stack, Text } from "@chakra-ui/react";

function App() {
	return (
		<Flex w="100vw" h="100vh" align="center" justify="center">
			<Flex
				direction="column"
				w="30%"
				h="50%"
				bg="gray.700"
				borderRadius="3px"
				boxShadow="0 0 10px black"
				align="center"
				justify="space-between"
				py="5%"
			>
				<Text fontFamily="'Raleway', sans-serif" fontSize="28px">
					Sign Up
				</Text>
				<Stack spacing={3} w="80%">
					<Input />
					<Input />
					<Input />
				</Stack>
				<Button>Sign up</Button>
			</Flex>
		</Flex>
	);
}

export default App;
