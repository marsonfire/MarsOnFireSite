# Mars On Fire — UI Redesign Spec

**Date:** 2026-05-15  
**Status:** Approved by user

---

## Overview

Redesign the Mars On Fire Angular frontend from a plain Material table into a visually striking game-studio showcase page. The new design uses a "Fiery & Bold" aesthetic — deep reds and oranges on a near-black background — to match the studio name and make each game feel like a product worth buying.

---

## Visual Direction

- **Theme:** Fiery & Bold
- **Background:** Near-black (`#0f0200`) with deep red gradient tones
- **Primary accent:** Fiery orange (`#ff6b1a`) with red (`#cc3300`)
- **Text hierarchy:** Orange for names/prices, muted gray for descriptions, dark gray for dates
- **Glow effects:** Subtle text-shadow on the title, hover glow on cards

---

## Page Structure

### Header (`#topBar`)
- Full-width bar with dark-to-black gradient background
- Studio name "MARS ON FIRE" in large (3.5rem), bold, uppercase, letter-spaced orange text with a glow text-shadow
- Subtitle "Indie Game Studio" in small uppercase tracking below
- A thin gradient underline separating the header from the content (fades from transparent → orange → transparent)

### Game Grid
- Section label: "Our Games" in small uppercase orange text with a left orange border accent
- CSS Grid layout: `repeat(auto-fill, minmax(280px, 1fr))` — wraps responsively
- Gap: 20px between cards

### Game Card
Each card contains:
1. **Game name** — orange, bold, 1rem
2. **Short description** — muted gray, small, multi-line
3. **Meta row** — price (orange, bold) on the left, release date (dark gray) on the right
4. **"View on Steam" button** — full-width, gradient red→orange, uppercase, bold

**Card style:**
- Dark semi-transparent background with a subtle orange tint
- Orange border (30% opacity at rest, 70% on hover)
- Rounded corners (12px)
- On hover: border brightens + soft orange box-shadow glow

### Coming Soon Games
- Price field shows "Coming Soon" in muted gray instead of a price
- Steam button is rendered as a disabled non-clickable element with dark muted styling

### Loading / Error States
- Loading: centered text "Loading..." in orange with letter-spacing
- Error: centered red error text (existing behavior, restyled)

---

## Implementation Scope

### Files to change
- `src/app/app.html` — replace the `mat-table` with a card grid using `@for`
- `src/app/app.css` — replace with the full Fiery & Bold styles
- `src/styles.css` — no changes needed
- `src/material-theme.scss` — no changes needed
- `src/app/app.ts` — no changes needed (signals and data fetching are already correct)

### Angular Material
- Remove `MatTableModule` import from `app.ts` — no longer needed
- No new Angular Material components required

### "Coming Soon" detection
- A game is "Coming Soon" if `game.price === 'Coming Soon'`
- Use `@if` inside the card template to conditionally render the disabled button vs the active link

---

## Constraints

- No new dependencies
- Keep existing signals (`isLoading`, `error`, `myGames`) and `ngOnInit` data-fetching logic untouched
- The `Game` interface in `app.ts` does not need to change
- Bootstrap is imported globally in `styles.css` but should not be relied on for the new design — use plain CSS in `app.css`
